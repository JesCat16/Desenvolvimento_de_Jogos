using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Animation_End : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
       }
    }
    void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }
}
