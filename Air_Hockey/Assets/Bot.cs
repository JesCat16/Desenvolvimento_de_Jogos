using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float boundY;
    public float fieldY;
    public float wallRightX;
    public float wallLeftX;
    public float velocity;

    private Transform locationBall;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        locationBall = GameObject.FindGameObjectWithTag("ball").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowBall();
    }

    private void FollowBall()
    {

        transform.position = Vector2.MoveTowards(transform.position, locationBall.position, velocity * Time.deltaTime);
        var pos = transform.position;

        if (pos.y < fieldY)
        {
            pos.y = fieldY;
        }
        else if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.x < wallRightX)
        {
            pos.x = wallRightX;
        }
        else if (pos.x > wallLeftX)
        {
            pos.x = wallLeftX;
        }
        transform.position = pos;
    }

}
