using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode moveLeft = KeyCode.A;      // Move a raquete para cima
    public KeyCode moveRight = KeyCode.D;    // Move a raquete para baixo
    public KeyCode Shoot = KeyCode.Space;
    public float speed = 10.0f;             // Define a velocidade da bola
    public float boundX;            // Define os limites em X
    public Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    public Lazer_Missel missel;
    public static System.Action hit;
    public static System.Action gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else
        {
            vel.x = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.x > boundX)
        {
            pos.x = boundX;
        }
        else if (pos.x < -boundX)
        {
            pos.x = -boundX;
        }
        transform.position = pos;

        if (Input.GetKeyDown(Shoot))
        {
            ShootLazer();
        }
    }

    private void ShootLazer()
    {
        Instantiate(missel, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("lazer"))
        {
            hit.Invoke();
        }

        if (collision.gameObject.CompareTag("invader"))
        {
            gameOver.Invoke();
        }
    }
}