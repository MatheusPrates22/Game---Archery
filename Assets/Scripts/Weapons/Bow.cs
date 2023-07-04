using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }
    public void StartAiming() {
        _animator.SetBool("aiming", true);
    }

    public void StopAiming() {
        _animator.SetBool("aiming", false);
    }

    public void Shoot() {
        Debug.Log("Shooting");
    }
}
