using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public static System.Action hit;
    private void OnTriggerEntre2d(Collider2D collision)
    {
        if(collision.GetComponent<enemycheck>())
        {
            hit.Invoke();
        }
    }
}
