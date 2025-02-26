using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBlocks : MonoBehaviour
{
    private int count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (count == 2)
            {

                Destroy(gameObject);
            }
            else
            {
                count++;
            }
        }
    }
}
