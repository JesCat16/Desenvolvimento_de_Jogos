using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laze_Missel : MonoBehaviour
{
    public Vector3 direc;

    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += direc * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
