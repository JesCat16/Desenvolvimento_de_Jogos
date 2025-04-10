using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public Dialogo dialogos;
    public void TriggerDialog()
    {
        DialogManager.Instance.StartDialog(dialogos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDialog();
        }
    }
}
