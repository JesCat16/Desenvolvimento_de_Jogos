using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private bool Lose = false;
    private bool next = false;
    private void Start()
    {
        playerDeath.playerDeathAction += GameOver;
        portal.portalAction += nextFase;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (next == true)
        {
            if (scene.name == "Fase01")
            {
                SceneManager.LoadScene("Fase02");
            }
            else if (scene.name == "Fase02")
            {
                SceneManager.LoadScene("Win");
            }
        }
        if (Lose == true)
        {
            SceneManager.LoadScene("Lose");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (scene.name == "Win" || scene.name == "Lose")
            {
                SceneManager.LoadScene("Tutorial");
            }
            else if (scene.name == "Tutorial")
            {
                SceneManager.LoadScene("Fase01");
            }

        }
        
    }
    private void GameOver()
    {
        Lose = true;
    }
    private void nextFase()
    {
        next = true;
    }
}
