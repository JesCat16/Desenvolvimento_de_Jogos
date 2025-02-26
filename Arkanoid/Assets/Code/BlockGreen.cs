using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGreen : MonoBehaviour
{
    private int count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (count == 1)
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
