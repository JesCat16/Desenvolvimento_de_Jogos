using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
   public static System.Action damaged;
   public playerMovement player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.KnockbackCounter = player.KnockbackTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.knockbackFromRight = true;
            }
            if (collision.transform.position.x >= transform.position.x)
            {
                player.knockbackFromRight = false;
            }
                damaged.Invoke();
        }
    }
}
