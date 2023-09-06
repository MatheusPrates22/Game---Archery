using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TetrisPlayerController : MonoBehaviour
{
    private TetrisInputAction tetrisInputAction;

    private void Awake() {
        tetrisInputAction = new TetrisInputAction();
    }

    private void OnEnable() {
        tetrisInputAction.Game.Enable();
        tetrisInputAction.Game.Rotate.performed += HandleRotatePiece;
        tetrisInputAction.Game.Plummet.performed += HandlePlummetPiece;
    }

    private void Update() {
        HandleShiftPiece();
        HandleFallPiece();
    }

    private void HandleShiftPiece() {
        float shiftPiece = tetrisInputAction.Game.Shift.ReadValue<float>();
        if (shiftPiece == -1) {
            TetrisManager.lastTetraminoeInstantiated.ShiftLeft();
        } else if (shiftPiece == 1) {
            TetrisManager.lastTetraminoeInstantiated.ShiftRight();
        }
    }

    private void HandleRotatePiece(InputAction.CallbackContext context) {
        TetrisManager.lastTetraminoeInstantiated.Rotate();
    }
    private void HandlePlummetPiece(InputAction.CallbackContext context) {
        TetrisManager.lastTetraminoeInstantiated.Plummet();
    }

    private void HandleFallPiece() {
        float fallPiece = tetrisInputAction.Game.Fall.ReadValue<float>();
        // Debug.Log(fallPiece);
        if (fallPiece == 1) {
            TetrisManager.lastTetraminoeInstantiated.Fall();
        }
    }

}
