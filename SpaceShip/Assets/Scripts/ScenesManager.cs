using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private bool Lose = false;
    private bool Win = false;
    private void Start()
    {
        GameManager.death += GameOver;
        GameManager.win += Victory;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if (Win == true)
        {
            if (scene.name == "SampleScene")
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
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void GameOver()
    {
        Lose = true;
    }
    private void Victory()
    {
        Win = true;
    }
}
