using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRed : MonoBehaviour
{
    private int count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (count == 3)
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
