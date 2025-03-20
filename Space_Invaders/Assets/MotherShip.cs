using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool spawned;
    private float spawnTime;
    private int rand;
    private float speed = 5.0f;
    private float Bound = 7.0f;
    public static System.Action MotherKill;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 1);
        spawnTime = Random.Range(1,10);
        rb2d = GetComponent<Rigidbody2D>();
        var vel = rb2d.velocity;
        vel.x = speed;
        rb2d.velocity = vel;
        Despawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned) return;
        if(rand == 0)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
            if(transform.position.x >= Bound)
            {
                Despawn();
            }
        }
        else
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
            if (transform.position.x >= -Bound)
            {
                Despawn();
            }
        }
        
    }
    private void Despawn()
    {
        spawned = false;
        gameObject.SetActive(false);
        Invoke(nameof(Spawn), spawnTime);
    }

    private void Spawn()
    {
        spawned = true;
        if(rand == 0)
        {
           transform.position = new Vector2(-Bound,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(Bound, transform.position.y);
        }
        gameObject.SetActive(true);
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("missel"))
        {
            MotherKill.Invoke();
            Destroy(this.gameObject);
        }
    }

}
