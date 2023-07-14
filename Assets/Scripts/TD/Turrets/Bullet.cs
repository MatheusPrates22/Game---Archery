using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform TargetTransform {get; set; }
    public CircleEnemy Enemy {get; set; }
    public int Damage {get; set; }
    [SerializeField] private float speed = 2f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (TargetTransform && Enemy) {
            Vector3 destination = TargetTransform.position;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, TargetTransform.position, speed * Time.deltaTime);
            transform.position = newPosition;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 0.05f) {
                Enemy.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
}
