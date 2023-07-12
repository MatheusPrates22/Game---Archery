using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private void Awake() {
        if (Instance == null) Instance = this;
    }

    public static Vector2 GetWorldMousePosition(){
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        // mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 worldMousePosition2Vector2 = new Vector2(worldMousePosition.x, worldMousePosition.y);
        return worldMousePosition2Vector2;
    }
}
