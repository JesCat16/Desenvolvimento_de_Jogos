using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }

        if (coll.collider.CompareTag("bot"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }
    }
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
