using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Brick");
        print(gos.Length);
        if (Input.GetKeyDown(KeyCode.Space) && scene.name == "Entre")
        {
            SceneManager.LoadScene("Fase1");
        }
        if (gos.Length == 0)
        {
            if (scene.name == "Fase1")
            {
                SceneManager.LoadScene("Fase2");
            }
            else if (scene.name == "Fase2")
            {
                SceneManager.LoadScene("Win");
            }
        }
        if(GameManager.Lifes == 0)
        {
            GameManager.Lifes = 3;
            SceneManager.LoadScene("Lose");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (scene.name == "Win" || scene.name == "Lose"))
        {
            SceneManager.LoadScene("Entre");
        }

    }
}
