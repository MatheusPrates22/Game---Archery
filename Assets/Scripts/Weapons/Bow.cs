using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    [SerializeField] GameObject startGO;
    [SerializeField] GameObject middleGO;
    [SerializeField] GameObject endGO;
    [SerializeField] Transform arrowTransform;

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
        // Debug.Log("Shooting");
    }

    public void PlaceArrowAtStartPosition(){
        Debug.Log("Starting position");
        middleGO.SetActive(false);
        endGO.SetActive(false);
        startGO.SetActive(true);
        arrowTransform.SetParent(startGO.transform);
        arrowTransform.localPosition = Vector3.zero;
        arrowTransform.gameObject.SetActive(true);
    }

    public void PlaceArrowAtMiddlePosition(){
        Debug.Log("Middle position");
        endGO.SetActive(false);
        startGO.SetActive(false);
        middleGO.SetActive(true);
        arrowTransform.SetParent(middleGO.transform);
        arrowTransform.localPosition = Vector3.zero;
        arrowTransform.gameObject.SetActive(true);
    }

    public void PlaceArrowAtEndPosition(){
        Debug.Log("End position");
        startGO.SetActive(false);
        middleGO.SetActive(false);
        endGO.SetActive(true);
        arrowTransform.SetParent(endGO.transform);
        arrowTransform.localPosition = Vector3.zero;
        arrowTransform.gameObject.SetActive(true);
    }

}
