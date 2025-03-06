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
    private float AttackRate = 1.0f;
    public Lazer_Missel lazer;
    public static System.Action killed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
        InvokeRepeating(nameof(lazerAttack), AttackRate, AttackRate);
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        timer += Time.deltaTime;
        if (timer >= waitTime){
            ChangeState();
            counter += 1;
            timer = 0.0f;
            if(counter > 5)
            {
                vel.x *= 2;
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

    private void lazerAttack()
    {
        if((Random.value < GameObject.FindGameObjectsWithTag("invader").Length) && GameObject.FindGameObjectsWithTag("lazer").Length < 5)
        {
            if(gameObject.activeSelf == true)
            {
                Instantiate(lazer, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missel"))
        {
            speed += 1;
            killed.Invoke();
            gameObject.SetActive(false);
        }
    }

}
