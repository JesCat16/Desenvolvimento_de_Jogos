using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public static System.Action hit;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<enemycheck>())
        {
            animator.SetBool("isDead", true);
        }
    }
}
