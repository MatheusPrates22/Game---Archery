using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [SerializeField] private float range;

    private Triangle triangle;

    private void Awake() {
        triangle = GetComponent<Triangle>();
    }

    private void Update() {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliderArray){
            if (collider.TryGetComponent<CircleEnemy>(out CircleEnemy enemy)){
                triangle.SetTarget(enemy);
            }
        }
    }
}
