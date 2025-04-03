using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartForWinAndLose : MonoBehaviour
{
    public GUISkin layout;
    public static System.Action restartAction;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 10, 120, 53), "RESTART"))
        {
            restartAction.Invoke();
        }
    }
}
