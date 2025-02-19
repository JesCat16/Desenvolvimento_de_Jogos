using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int BotScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }

    public static void Score(string golID)
    {
        if (golID == "golBot")
        {
            PlayerScore1++;
        }
        else if(golID == "golPlayer")
        {
            BotScore2++;
        }
    }
    // Gerência da pontuação e fluxo do jogo
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + BotScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 34, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            BotScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (BotScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

}
