using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    private int Lives = 3;
    private int points = 0;
    // Start is called before the first frame update
    private void pointsome()
    {
        points = points + 100;
    }
    private void livesub()
    {
        Lives = Lives - 1;
    }

    private void Update()
    {
        Invaders.killed += pointsome;
        player.hit += livesub;
    }
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 100), "" + Lives);
        GUI.Label(new Rect(Screen.width / 2 - 150, 50, 100, 100), "" + points);
    }
}
