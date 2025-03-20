using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUISkin layout;
    private int Lives = 3;
    private int points = 0;
    public static System.Action death;
    // Start is called before the first frame update
    private void pointsome()
    {
        points = points + 100;
    }
    private void livesub()
    {
        Lives = Lives - 1;
    }

    private void bigpoint()
    {
        points = points + 500;
    }

    private void Start()
    {
        Invaders.killed += pointsome;
        player.hit += livesub;
        MotherShip.MotherKill += bigpoint;
    }

    private void Update()
    {
        if(Lives == 0)
        {
            death.Invoke();
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 100), "" + Lives);
        GUI.Label(new Rect(Screen.width / 2 - 150, 50, 100, 100), "" + points);
    }
}
