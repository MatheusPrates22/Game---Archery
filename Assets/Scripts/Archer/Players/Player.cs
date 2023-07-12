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

}
