using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cometa : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 speed = new Vector2(2, 2);
    private Vector2 movement;
    public Vector2 direction = new Vector2(-1, 0);
    private Transform wallLocation;
    //private float AttackRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        wallLocation = GameObject.FindGameObjectWithTag("wall").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement = new Vector2(direction.x * speed.x, direction.y * speed.y);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = movement;
    }
}
