using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBlue : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Destroy(gameObject);
        }
    }
}
