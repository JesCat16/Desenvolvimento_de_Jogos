using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Lifes = 3;

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Refer�ncia ao objeto bola

    Scene scene = SceneManager.GetActiveScene();

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("ball"); // Busca a refer�ncia da bola
    }
    
    public static void Life()
    {
        Lifes--;
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Lifes);

        if(Lifes == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
