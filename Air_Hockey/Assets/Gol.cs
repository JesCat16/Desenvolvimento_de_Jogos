using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gol : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
