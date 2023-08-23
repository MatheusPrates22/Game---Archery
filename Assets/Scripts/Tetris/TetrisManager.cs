using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TetrisManager : MonoBehaviour
{
    private static TetrisManager Instance;

    public enum TetraminoesBlock {I, J, L, O, S, T, Z}

    [SerializeField] private KeyCode newBlockKeyCode = KeyCode.N;
    [SerializeField] private KeyCode rotateBlockKeyCode = KeyCode.R;
    [SerializeField] private GameObject[] piecesPrefab;
    [SerializeField] private Transform spawnPointTransform;


    private void Awake() {
        if (Instance == null) Instance = this; else Destroy(Instance);
    }

    private void Update() {
        if (Input.GetKeyDown(newBlockKeyCode)) {
            InstantiateRandomTetramino();
        }
        if (Input.GetKeyDown(rotateBlockKeyCode)) {
            InstantiateTetraminoes(GetRandomTetramino());
        }
    }

    public static GameObject InstantiateRandomTetramino() {
        return InstantiateTetraminoes(GetRandomTetramino());
    }

    public static GameObject InstantiateTetraminoes(TetraminoesBlock tetraminoe) {
        switch (tetraminoe) {
            case TetraminoesBlock.I:
                return Instantiate(Instance.piecesPrefab[0], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.J:
                return Instantiate(Instance.piecesPrefab[1], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.L:
                return Instantiate(Instance.piecesPrefab[2], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.O:
                return Instantiate(Instance.piecesPrefab[3], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.S:
                return Instantiate(Instance.piecesPrefab[4], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.T:
                return Instantiate(Instance.piecesPrefab[5], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            case TetraminoesBlock.Z:
                return Instantiate(Instance.piecesPrefab[6], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
            default:
                GameObject newGameObject = new GameObject();
                return newGameObject;
        }
    }

    private static TetraminoesBlock GetRandomTetramino() {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(TetraminoesBlock));
        TetraminoesBlock randomTetramino = (TetraminoesBlock)values.GetValue(random.Next(values.Length));
        return randomTetramino;
    }


}
