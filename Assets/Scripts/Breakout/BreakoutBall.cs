using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutBall : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    private void LaunchBall()
    {
        float randomDirection = Random.Range(-1f, 1f);
        direction = new Vector2(randomDirection, 1).normalized;
        rb.velocity = direction * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player")) {
            // direction = new Vector2(direction.x, 1);
            direction = new Vector2(GetRelativePositionPointFromPaddle(collision.transform.position, collision.transform.localScale.x), 1);
            rb.velocity = direction * initialSpeed;
        } 
        else
        if (collision.gameObject.CompareTag("Breakout Block")) {
            direction = new Vector2(direction.x, -direction.y);
            rb.velocity = direction * initialSpeed;
            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.CompareTag("Breakout Ceiling")) {
            direction = new Vector2(direction.x, -direction.y);
            rb.velocity = direction * initialSpeed;
        }
        else
        if (collision.gameObject.CompareTag("Breakout Walls")) {
            direction = new Vector2(-direction.x, direction.y);
            rb.velocity = direction * initialSpeed;
        }
        else
        if (collision.gameObject.CompareTag("Breakout Floor")) {
            direction = Vector2.zero;
            rb.velocity = direction * initialSpeed;
        }
    }

    private float GetRelativePositionPointFromPaddle(Vector2 paddlePosition, float paddleWidth){
        float relativeCollisionPoint = (transform.position.x - paddlePosition.x) / (paddleWidth / 2);

        Debug.Log("Posição relativa da colisão: " + relativeCollisionPoint);

        return relativeCollisionPoint;
    }
}
