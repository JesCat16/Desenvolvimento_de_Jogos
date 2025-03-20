using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cometa : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float speed;
    private Vector2 movement;
    public Vector2 direction = new Vector2(-1, 0);
    private Transform wallLocation;
    public static System.Action destroyed;
    // Start is called before the first frame update
    void Start()
    {
        wallLocation = GameObject.FindGameObjectWithTag("wall").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (GameManager.slowmotionactive)
        {
            speed = 1.5f;
        }
        else
        {
            speed = 4.5f;
        }
        movement = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("missel"))
        {
            destroyed.Invoke();
            Destroy(gameObject);
        }

    }
}
