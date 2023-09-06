using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class TetrisManager : MonoBehaviour
{
    public enum TetraminoesBlock {I, J, L, O, S, T, Z}
    private static TetrisManager Instance;


    [SerializeField] private KeyCode newBlockKeyCode = KeyCode.N;
    [SerializeField] private GameObject[] piecesPrefab;
    [SerializeField] private Transform spawnPointTransform;
    [SerializeField] private float blockFallTime = 1f;

    public static TetraminoeBlock lastTetraminoeInstantiated {get; private set;}

    private float currentBlockFallTime;

    private void Awake() {
        if (Instance == null) Instance = this; else Destroy(Instance);
    }

    private void Start() {
        lastTetraminoeInstantiated = InstantiateRandomTetraminoe();
    }

    private void Update() {
        
        if (Input.GetKeyDown(newBlockKeyCode)) {
            lastTetraminoeInstantiated = InstantiateRandomTetraminoe();
        }
        if (lastTetraminoeInstantiated != null) {
            currentBlockFallTime += Time.deltaTime;
            if (currentBlockFallTime > blockFallTime) {
                lastTetraminoeInstantiated.Fall();
                currentBlockFallTime = 0f;
            }
        }
    }

    public static TetraminoeBlock InstantiateRandomTetraminoe() {
        return InstantiateTetraminoes(GetRandomTetraminoe());
    }

    public static TetraminoeBlock InstantiateTetraminoes(TetraminoesBlock tetraminoe)
    {
        GameObject instantiatedGameObject = null;

        switch (tetraminoe) {
            case TetraminoesBlock.I:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[0], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.J:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[1], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.L:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[2], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.O:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[3], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.S:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[4], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.T:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[5], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            case TetraminoesBlock.Z:
                instantiatedGameObject = Instantiate(Instance.piecesPrefab[6], Instance.spawnPointTransform.position, Quaternion.identity, Instance.spawnPointTransform);
                break;
            default:
                instantiatedGameObject = new GameObject();
                break;
        }

        TetraminoeBlock tetraminoePiece = instantiatedGameObject.GetComponent<TetraminoeBlock>();

        tetraminoePiece.tetraminoesBlock = tetraminoe;
        tetraminoePiece.OnFallEnd += Instance.LastTetraminoeInstantiated_OnFallEnd;

        return tetraminoePiece;
    }


    public static TetraminoesBlock GetRandomTetraminoe() {
        System.Random random = new System.Random();
        Array values = Enum.GetValues(typeof(TetraminoesBlock));
        TetraminoesBlock randomTetramino = (TetraminoesBlock)values.GetValue(random.Next(values.Length));
        return randomTetramino;
    }

    private void LastTetraminoeInstantiated_OnFallEnd(object sender, EventArgs e) {
        lastTetraminoeInstantiated.OnFallEnd -= LastTetraminoeInstantiated_OnFallEnd;
        lastTetraminoeInstantiated = InstantiateRandomTetraminoe();
    }

}
