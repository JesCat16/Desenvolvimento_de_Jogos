using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    Vector3 direcao;
    // Start is called before the first frame update

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direcao = Vector3.forward;

    }
    private void Update()
    {
        rb2d.AddForce(direcao, (ForceMode2D)ForceMode.VelocityChange);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            direcao = Vector3.Reflect(rb2d.velocity, coll.contacts[0].normal);
        }

        else if (coll.collider.CompareTag("bot"))
        {
            direcao = Vector3.Reflect(rb2d.velocity, coll.contacts[0].normal);
        }

        else
        {
            direcao = Vector3.Reflect(rb2d.velocity, coll.contacts[0].normal);
        }
       
    }
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
