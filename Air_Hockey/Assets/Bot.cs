using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public float boundY = 12.4f;
    public float fieldY = -1.19f;
    public float wallRightX = -5.5f;
    public float wallLeftX = 5f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        var pos = transform.position;

        if (pos.y < fieldY)
        {
            pos.y = fieldY;
        }
        else if (pos.y > boundY)
        {
            pos.y = boundY;
        }

        if (pos.x < wallRightX)
        {
            pos.x = wallRightX;
        }
        else if (pos.x > wallLeftX)
        {
            pos.x = wallLeftX;
        }
    }
}
