using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.S;    // Move a raquete para baixo
    //public KeyCode Shoot = KeyCode.Space;
    public float speed = 10.0f;             // Define a velocidade da bola
    public float boundY;            // Define os limites em X
    public Rigidbody2D rb2d;
    public static System.Action hit;// Define o corpo rigido 2D que representa a raquete
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
        if (Input.GetKey(moveUp))
        {             // Velocidade da Raquete para ir para cima
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {      // Velocidade da Raquete para ir para cima
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;                          // Velociade para manter a raquete parada
        }
        rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

        var pos = transform.position;           // Acessa a Posição da raquete
        if (pos.y > boundY)
        {
            pos.y = boundY;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
        }
        transform.position = pos;               // Atualiza a posição da raquete
    }
}

