using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float boundY = -8.4f;
    public float fieldY = -0.01f;
    public float wallRightX = -6f;
    public float wallLeftX = 8f;
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


        if (pos.x > wallRightX)
        {
            pos.x = wallRightX;
        }
        else if (pos.x < wallLeftX)
        {
            pos.x = wallLeftX;
        }
        transform.position = pos;

    }
}
