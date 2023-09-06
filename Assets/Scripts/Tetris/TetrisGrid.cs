using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public Vector2Int Cord {get; private set;}

    public bool HasPiece {get; set;}

    public void Initiate(Vector2Int cord) {
        this.Cord = cord;
        HasPiece = false;
        gameObject.name = "Grid " + cord.x + " " + cord.y;
    }

}
