using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float boundY;
    public float fieldY;
    public float wallRightX;
    public float wallLeftX;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;


        if (pos.y > fieldY)
        {
            pos.y = fieldY;
        }
        else if (pos.y < boundY)
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
        transform.position = pos;

    }
}
