using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontua��o do player 1
    public static int BotScore2 = 0; // Pontua��o do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Refer�ncia ao objeto bola

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball"); // Busca a refer�ncia da bola
    }

    public static void Score(string golID)
    {
        if (golID == "Gol_Bot")
        {
            PlayerScore1++;
        }
        else if(golID == "Gol_Player")
        {
            BotScore2++;
        }
    }
    // Ger�ncia da pontua��o e fluxo do jogo
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + BotScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 10, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            BotScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (BotScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "BOT WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

}
