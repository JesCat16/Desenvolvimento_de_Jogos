using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola

    // inicializa a bola randomicamente para esquerda ou direita
    void GoBall()
    {
       rb2d.AddForce(new Vector2(20, -15));  
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        GoBall();    // Chama a função GoBall após 2 segundos
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes)
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x * 2;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = (new Vector2(-0.02f, -5.72f));
    }

    // Reinicializa o jogo
    void RestartGame()
    {
        ResetBall();
        GoBall();
    }
}
