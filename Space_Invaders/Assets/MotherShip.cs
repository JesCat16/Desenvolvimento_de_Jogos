using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class MotherShip : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool spawned;
    private float spawnTime;
    private int rand;
    private float speed = 5.0f;
<<<<<<< Updated upstream
    private float boundX = 7.25f;
    private Transform locateWall;
=======
    private float Bound = 7.0f;
>>>>>>> Stashed changes
    public static System.Action MotherKill;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        locateWall = GameObject.FindGameObjectWithTag("wall2").transform;
=======
        rand = Random.Range(0, 1);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
       
=======
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
        
>>>>>>> Stashed changes
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
        transform.position = Vector2.MoveTowards(transform.position, locateWall.position, speed * Time.deltaTime);
        var pos = transform.position;

        if (pos > boundX)
        {
            Despawn();
        }
        transform.position = pos;
    }

    void ChangeState()
    {
        var vel = rb2d.velocity;
        vel.x *= -1;
        rb2d.velocity = vel;
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
