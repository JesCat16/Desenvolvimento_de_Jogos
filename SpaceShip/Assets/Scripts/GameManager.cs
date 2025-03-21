using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    private int Lives = 3;
    private int points = 0;
    public static System.Action death;
    public static System.Action win;
    private float timer = 0f;
    private static bool slowmotionwasactive = false;
    public static bool slowmotionactive = false;
    // Start is called before the first frame update
    private void pointsomeNave()
    {
        points = points + 100;
    }
    private void pointsomeCometa()
    {
        points = points + 50;
    }
    private void livesub()
    {
        Lives = Lives - 1;
    }

    private void Start()
    {
        Nave.killed += pointsomeNave;
        Cometa.destroyed += pointsomeCometa;
        Player.hit += livesub;
    }

    private void Update()
    {
        if (Lives == 0)
        {
            death.Invoke();
        }

        if(points > 500 && slowmotionwasactive == false)
        {
            if (timer > 60000)
            {
                slowmotionactive = true;
                timer += Time.deltaTime;
            }
            else
            {
                slowmotionactive = false;
                slowmotionwasactive = true;
            }
        }

        if(points > 1000)
        {
            win.Invoke();
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 100), "" + Lives);
        GUI.Label(new Rect(Screen.width / 2 - 150, 50, 100, 100), "" + points);
    }
}
