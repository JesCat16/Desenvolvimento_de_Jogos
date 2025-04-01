using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycheck : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<HitCheck>())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * 300f);
        }
    }
}
