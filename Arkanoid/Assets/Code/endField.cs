using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endField : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "ball")
        {
            GameManager.Life();
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}
