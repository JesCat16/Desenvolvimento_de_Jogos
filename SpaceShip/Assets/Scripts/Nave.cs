using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private float speed;
    public Vector2 direction = new Vector2(-1, 0);
    private Transform wallLocation;
    private float AttackRate = 1.0f;
    public Lazer_Missel lazer;
    public static System.Action killed;

    // Start is called before the first frame update
    void Start()
    {
        wallLocation = GameObject.FindGameObjectWithTag("wall").transform;
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(lazerAttack), AttackRate, AttackRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.slowmotionactive)
        {
            speed = 2.5f;
        }
        else
        {
            speed = 5.0f;
        }
        movement = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }
    private void lazerAttack()
    {
        if (gameObject.activeSelf == true)
        {
            Instantiate(lazer, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("missel"))
        {
            killed.Invoke();
            Destroy(gameObject);
        }

    }
}
