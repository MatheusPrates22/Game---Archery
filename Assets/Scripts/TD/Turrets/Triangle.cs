using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField] private Transform bulletRespawnTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootWaitingTimer = 1.0f;
    [SerializeField] private int damage = 5;

    private float shootTimer;
    private float range;
    private int damageAmount;
    private CircleEnemy enemy;

    private void Update() {
        LookToEnemy();
        Attack();
    }

    public void SetTarget(CircleEnemy enemy){
        this.enemy = enemy;
    }

    private void Attack() {
        if (shootTimer >= shootWaitingTimer){
            if (enemy) {
                shootTimer = 0f ;
                SpawnBullet();
                // enemy.TakeDamage(5);
            }
        } else {
            shootTimer += Time.deltaTime;
        }
    }

    private void LookToEnemy() {
        if (enemy) {
            Vector2 enemyPosition = enemy.transform.position;

            float angle = Mathf.Atan2(enemyPosition.y - transform.position.y, enemyPosition.x - transform.position.x);
            float angleDegree = angle * Mathf.Rad2Deg;
            float offset = -90f;

            transform.rotation = Quaternion.Euler(0f, 0f, angleDegree + offset);
        }
    }

    private void SpawnBullet() {
        GameObject bulletGO = Instantiate(bulletPrefab, bulletRespawnTransform.position, transform.rotation, transform);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.TargetTransform = enemy.transform;
        bullet.Enemy = enemy;
        bullet.Damage = damage;
    }
}
