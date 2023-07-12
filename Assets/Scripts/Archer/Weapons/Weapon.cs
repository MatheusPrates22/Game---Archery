using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject eyesGO;
    [SerializeField] private Bow bow;

    void Update()
    {
        LookToMousePosition();
    }

    private void LookToMousePosition()
    {
        Vector2 mousePosition = GameController.GetWorldMousePosition();
        Vector2 eyesPosition = new Vector2(eyesGO.transform.position.x, eyesGO.transform.position.y);

        float angle = Mathf.Atan2(mousePosition.y - eyesPosition.y, mousePosition.x - eyesPosition.x);
        float angleDregree = angle * Mathf.Rad2Deg;
        // Debug.Log($"Mouse: {mousePosition}, Eyes: {eyesPosition}, Angle: {angle}, AngleDregree: {angleDregree}");

        transform.rotation = Quaternion.Euler(0f, 0f, angleDregree);
    }

    public void Aim(InputAction.CallbackContext callbackContext){
        if (callbackContext.started){
            bow.gameObject.SetActive(true);
            bow.StartAiming();
        }
        if (callbackContext.performed){
            bow.Shoot();
        }
        if (callbackContext.canceled){
            bow.gameObject.SetActive(false);
            bow.StopAiming();
        }
    }

    public void Shoot(InputAction.CallbackContext callbackContext){
        if (callbackContext.performed){
            Debug.Log("Shotted");
        }
    }
}
