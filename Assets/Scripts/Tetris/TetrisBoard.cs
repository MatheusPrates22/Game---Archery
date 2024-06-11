using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBoard : MonoBehaviour
{
    private static TetrisBoard Instance;

    private const int HEIGHT = 20;
    private const int WIDTH = 10;

    // [SerializeField] private Transform topLeftGridTransform;
    // [SerializeField] private Transform topRightGridTransform;
    // [SerializeField] private Transform bottomLeftGridTransform;
    // [SerializeField] private Transform bottomRightGridTransform;
    // [SerializeField] private Transform spawnNewPieceTransform;
    [SerializeField] private Transform gridsTransform;
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject borderPrefab;

    public static List<TetraminoeBlock> blocks {get; private set;}
    public static TetrisGrid[,] grids;

    private void Awake() {
        if (Instance == null) Instance = this; else Destroy(Instance);
        blocks = new List<TetraminoeBlock>();
        InitGrid();
    }
    
    public static bool IsValidMode(Vector2Int cord) {
        if (IsInsideBoard(cord))
            return true;
        return false;
    }

    public static bool IsInsideBoard(Vector2Int cord) {
        if (cord.x < 0 || 
            cord.x > WIDTH || 
            cord.y < 0 || 
            cord.y > HEIGHT) 
            return false;
        return true;
    }

    public static bool IsInsideBoard(Vector3 cord) {
        if (cord.x < 0 || 
            cord.x > WIDTH || 
            cord.y < 0 || 
            cord.y > HEIGHT) 
            return false;
        return true;
    }

    public static bool HasAnyPiece(Vector2Int cord) {
        for (int i = 0; i < WIDTH; i++) {
            for (int j = 0; j < HEIGHT; j++) {
                if (grids[i, j].HasPiece)
                    return true;
            }
        }
        return false;
    }

    public static void NewBlockPlacement(TetraminoeBlock tetraminoePiece) {
        blocks.Add(tetraminoePiece);
        // for () {

        // }
    }

    private void InitGrid() {
        grids =  new TetrisGrid[WIDTH, HEIGHT];
        for (int i = 0; i < WIDTH; i++) {
            for (int j = 0; j < HEIGHT; j++) {
                grids[i, j] = new TetrisGrid();
                Vector3 pos = new Vector3((float)(-WIDTH/2 + 0.5 + i), (float)(-HEIGHT/2 + 0.5 + j), 0);
                GameObject gridGO = Instantiate(gridPrefab, pos, Quaternion.identity, gridsTransform);

                TetrisGrid tetrisGrid = gridGO.GetComponent<TetrisGrid>();

                tetrisGrid.Initiate(new Vector2Int(i, j));
            }
        }

        GameObject borderGO = Instantiate(borderPrefab, Vector3.zero , Quaternion.identity, transform);
        borderGO.name = "Border";
    }
}
