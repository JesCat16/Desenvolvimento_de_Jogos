using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI texto;
    public bool isTalking;
    public Animator animator;

    private Queue<string> text;
    public static DialogManager Instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        text = new Queue<string>();
    }

    public void StartDialog(Dialogo dialog)
    {
        animator.SetBool("isTalking", true);
        isTalking = true;

        nameText.text = dialog.name;
        text.Clear();
        foreach (string line in dialog.text)
        {
            text.Enqueue(line);
        }
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (text.Count == 0)
        {
            EndDialog();
            return;
        }
        string line = text.Dequeue();
        texto.text = line;
        Debug.Log(line);
    }
    void EndDialog()
    {
        animator.SetBool("isTalking", false);
        isTalking = false;
    }
}
