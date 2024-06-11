using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakoutPlayer : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 paddlePosition;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        paddlePosition = transform.position;
        paddlePosition.x += input * speed * Time.deltaTime;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, -7.5f, 7.5f);
        transform.position = paddlePosition;
    }
}
