using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraminoeBlock : MonoBehaviour
{
    private const float SHIFT_TIMER = 0.2f; 
    private const float FALL_TIMER = 0.2f; 

    public event EventHandler OnFallEnd;

    public TetrisManager.TetraminoesBlock tetraminoesBlock {get; set; }

    public Vector2Int[] piecesPosition;

    private int rotateAngle = 90;
    private float currentShiftTimer = 0f;
    private float currentFallTimer = 0f;

    private void Start() {
        if (tetraminoesBlock == TetrisManager.TetraminoesBlock.I || tetraminoesBlock == TetrisManager.TetraminoesBlock.O) {
            transform.position += new Vector3(-0.5f, -0.5f, 0);
        }
        piecesPosition = new Vector2Int[4];
    }

    private void Update() {
        currentShiftTimer += Time.deltaTime;
        currentFallTimer += Time.deltaTime;
    }

    public void ShiftLeft() {
        if (CanMoveLeft() && CanShift()) {
            transform.position += Vector3.left;
        }
    }

    public void ShiftRight() {
        if (CanMoveRight() && CanShift()) {
            transform.position += Vector3.right;
        }
    }

    public void Rotate() {
        transform.Rotate(new Vector3(0, 0, rotateAngle));
        // rotateAngle *= -1;
    }

    public void Fall() {
        if (CanMoveDown() && CanFall()) {
            transform.position += Vector3.down;
        }
    }

    public void Plummet() {
        while (CanMoveDown()) {
            transform.position += Vector3.down;
        }
        BlockFallEnd();
    }

    private void BlockFallEnd() {
        
        OnFallEnd?.Invoke(this, EventArgs.Empty);
    } 

    private bool CanShift() {
        if (currentShiftTimer > SHIFT_TIMER) {
            currentShiftTimer = 0f;
            return true;
        }
        return false;
    }
    private bool CanFall() {
        if (currentFallTimer > FALL_TIMER) {
            currentFallTimer = 0f;
            return true;
        }
        return false;
    }

    private bool CanMoveLeft() {
        foreach(Transform squareChild in transform) {
            Vector3 newPosition = squareChild.position + Vector3.left;

            if (!TetrisBoard.IsInsideBoard(newPosition)) {
                return false;
            }
        }
        return true;
    }
    private bool CanMoveRight() {
        foreach(Transform squareChild in transform) {
            Vector3 newPosition = squareChild.position + Vector3.right;
            if (!TetrisBoard.IsInsideBoard(newPosition)) {
                return false;
            }
        }
        return true;
    }
    private bool CanRotate() {
        foreach(Transform squareChild in transform) {
            Vector3 newPosition = squareChild.position + Vector3.right;
            if (!TetrisBoard.IsInsideBoard(newPosition)) {
                return false;
            }
        }
        return true;
    }

    private bool CanMoveDown() {
        foreach (Transform squareChild in transform) {
            Vector3 newPosition = squareChild.position + Vector3.down;
            if (!TetrisBoard.IsInsideBoard(newPosition)) {
                return false;
            }
        }
        return true;
    }
}
