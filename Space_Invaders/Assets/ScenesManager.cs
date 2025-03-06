using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private bool Lose = false;
    private void Start()
    {
        GameManager.death += GameOver;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] gos = GameObject.FindGameObjectsWithTag("invader");
        print(gos.Length);
        if (gos.Length == 0)
        {
            if (scene.name == "Game")
            {
                SceneManager.LoadScene("Win");
            }
        }
        if (Lose == true)
        {
            SceneManager.LoadScene("Lose");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (scene.name == "Win" || scene.name == "Lose"))
        {
            SceneManager.LoadScene("Game");
        }
    }
    private void GameOver()
    {
        Lose = true;
    }
}
