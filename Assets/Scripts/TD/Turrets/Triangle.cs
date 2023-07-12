using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField] private Transform bulletRespawnTransform;
    private float range;
    private int damageAmount;
    private float shootTimerMax;
    private float shootTimer;
    private CircleEnemy enemy;

    public void SetTarget(CircleEnemy enemy){
        this.enemy = enemy;
    }
}
