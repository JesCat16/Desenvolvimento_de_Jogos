using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 speed = new Vector2(2,2);
    private Vector2 movement;
    public Vector2 direction = new Vector2(-1,0);
    private Transform wallLocation;
    private float AttackRate = 1.5f;
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
        movement = new Vector2(direction.x * speed.x, direction.y * speed.y);
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
        else if(collision.gameObject.CompareTag("missel"))
        {
            killed.Invoke();
            Destroy(gameObject);
        }

    }
}
