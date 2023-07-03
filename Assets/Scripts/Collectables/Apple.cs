using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public GameObject collected;

    [SerializeField] private float timeToDestroyWhenTriggered = 0.25f;

    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            collected.SetActive(true);
            Destroy(gameObject, timeToDestroyWhenTriggered);
        }
    }

}
