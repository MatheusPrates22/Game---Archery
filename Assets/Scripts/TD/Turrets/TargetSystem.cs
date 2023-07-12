using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Color color = Color.white;

    private Triangle triangle;
    private bool hasAnyEnemyAsTarget;
    private CircleEnemy enemyTarget;

    private void Awake() {
        triangle = GetComponent<Triangle>();
    }

    private void Update() {
        SearchForEnemy();
    }

    private void SearchForEnemy()
    {
        if (hasAnyEnemyAsTarget && enemyTarget) {
            Debug.DrawLine(transform.position, enemyTarget.transform.position);
            if (IsEnemyOutsideRadius()) {
                hasAnyEnemyAsTarget = false;
                enemyTarget = null;
                triangle.SetTarget(null);
            }
        } else {
            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, range);
            foreach (Collider2D collider in colliderArray){
                //Se encontrou gameobject com componente CircleEnemy
                if (collider.TryGetComponent<CircleEnemy>(out CircleEnemy enemy)){
                    //Se não tem nenhum inimigo como algo
                    if (!enemyTarget) { 
                        enemyTarget = enemy;
                    } 
                    //Se inimigo encontrado tem vem antes do já selecionado
                    else if (enemy.WaveIndex < enemyTarget.WaveIndex) {
                        enemyTarget = enemy;
                    }
                    triangle.SetTarget(enemyTarget);
                    hasAnyEnemyAsTarget = true;
                }
            } 
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private bool IsEnemyOutsideRadius() {
        float distance = Vector2.Distance(transform.position, enemyTarget.transform.position);
        if (distance > range) {
            return true;
        }
        return false;
    }
}
