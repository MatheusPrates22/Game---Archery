using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Vector2 force = new Vector2(700, 50);
    // [SerializeField] private float gravityScale = 0.5f;
    
    // Posição inicial da flecha
    private Vector3 startPos;

    // Velocidade da flecha
    public float arrowSpeed = 5f;

    // Estados da flecha
    private const int FLECHA_PARADA = 0;
    private const int FLECHA_SUBINDO = 1;
    private const int FLECHA_CAINDO = 2;

    private int flechaEstado = FLECHA_PARADA;

    // Referência ao Rigidbody
    private Rigidbody2D rb;

    void Start()
    {
        // Salva a posição inicial da flecha
        startPos = transform.position;

        // Obtém a referência ao Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica o input do teclado
        if (Input.GetKeyDown(KeyCode.H))
        {
            ResetarFlecha();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            ArremessarFlecha();
        }

        // Atualiza a posição da flecha
        if (flechaEstado == FLECHA_SUBINDO)
        {
            rb.velocity = Vector2.up * arrowSpeed;

            if (transform.position.y >= startPos.y)
            {
                flechaEstado = FLECHA_CAINDO;
                rb.velocity = Vector2.zero;
            }
        }
        else if (flechaEstado == FLECHA_CAINDO)
        {
            rb.velocity = Vector2.down * arrowSpeed;
        }
    }

    void ResetarFlecha()
    {
        flechaEstado = FLECHA_PARADA;
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }

    void ArremessarFlecha()
    {
        flechaEstado = FLECHA_SUBINDO;
    }
}
