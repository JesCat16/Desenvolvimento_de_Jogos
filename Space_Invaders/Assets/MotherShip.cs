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
    public static System.Action MotherKill;

    // Start is called before the first frame update
    void Start()
    {
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
       //var vel = rb2d.velocity;
       //timer += Time.deltaTime;
       //if (timer >= waitTime)
       //{
       //   ChangeState();
       //   cycle -= 1;
       //   timer = 0.0f;
       //}
       //if (cycle == 0)
       //{
       //   Despawn();
       //}
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
