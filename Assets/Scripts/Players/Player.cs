using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector2 _move;
    private bool _isJumping;
    private bool _doubleJump = false;

    [SerializeField] private GameObject weaponGO;
    [SerializeField] private GameObject eyesGO;
    [SerializeField] private Bow bow;
    [SerializeField] private float jumpForce = 300f;
    [SerializeField] private float moveSpeed = 300f;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(InputAction.CallbackContext callbackContext){
        _move = callbackContext.ReadValue<Vector2>();
        if (_move.x > 0) {
            _animator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } else if (_move.x < 0) {
            _animator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        } else {
            _animator.SetBool("Walk", false);
        }
    }

    public void Jump(InputAction.CallbackContext callbackContext){
        if (callbackContext.performed){
            if (!_isJumping){
                _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                _doubleJump = true;
                _animator.SetBool("Jump", true);
            }
            else
            {
                if (_doubleJump) {
                    _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    _doubleJump = false;
                }
            }
        }
    }

    public void Aim(InputAction.CallbackContext callbackContext){
        if (callbackContext.started){
            weaponGO.SetActive(true);
            bow.StartAiming();
        }
        if (callbackContext.performed){
            bow.Shoot();
        }
        if (callbackContext.canceled){
            weaponGO.SetActive(false);
            bow.StopAiming();
        }
    }

    public void Shoot(InputAction.CallbackContext callbackContext){
        if (callbackContext.performed){
            
        }
    }

    private void Update() {
        // if (Mouse.current.leftButton.wasPressedThisFrame){
        Vector2 mousePosition = GetWorldMousePosition();
        Vector2 eyesPosition = new Vector2(eyesGO.transform.position.x, eyesGO.transform.position.y);
        // transform.eulerAngles = new Vector3(0f, 0f, 0f);
        Debug.DrawLine(mousePosition, eyesPosition, Color.red);
        float radAngle = Vector2.Angle(mousePosition, eyesPosition);
        float degreeAngle = radAngle * Mathf.Rad2Deg;
        Debug.Log(degreeAngle);
        // weaponGO.transform.eulerAngles = Vector2.Angle(mousePosition, eyesPosition);
        // }
    }

    private void FixedUpdate() {
        _rb.AddForce(new Vector3(_move.x, 0, _move.y) * Time.fixedDeltaTime * moveSpeed, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 8) {
            _isJumping = false;
            _animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.layer == 8) {
            _isJumping = true;
        }
    }

    private Vector2 GetWorldMousePosition(){
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        // mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 worldMousePosition2Vector2 = new Vector2(worldMousePosition.x, worldMousePosition.y);
        return worldMousePosition2Vector2;
    }
}
