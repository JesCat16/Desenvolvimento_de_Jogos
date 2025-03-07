using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class MotherShip : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool spawned;
    private int cycle = 10;
    private float spawnTime;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 5.0f;
    private float boundX = 7.25f;
    private Transform locateWall;
    public static System.Action MotherKill;

    // Start is called before the first frame update
    void Start()
    {
        locateWall = GameObject.FindGameObjectWithTag("wall2").transform;
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
