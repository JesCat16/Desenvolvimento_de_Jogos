using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;
    private int counter = 0;

    // Start is called before the first frame update
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
        timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            counter += 1;
            timer = 0.0f;
            if(counter > 4)
            {
                ChangeStateDown();
                counter = 0;
            }
            
        }
    }

    void ChangeState(){
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
    }

    void ChangeStateDown()
    {
        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("missel"))
        {
            gameObject.SetActive(false);
        }
    }

}
