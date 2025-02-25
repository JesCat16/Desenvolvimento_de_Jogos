using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRed : MonoBehaviour
{
    private int count = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(count == 4)
        {
            if(collision.gameObject.CompareTag("ball"))
            {
                Destroy(gameObject);
            }
        }else
        {
            count++;
        }
    }
}
