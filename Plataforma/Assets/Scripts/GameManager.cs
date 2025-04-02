using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    public GUISkin layout;
    private int Lives = 3;
    private int coins = 0;

    private void livesub()
    {
        Lives = Lives - 1;
    }
    private void addPoints()
    {
        coins = coins + 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement.addCoin += addPoints;
        enemyDamage.damaged += livesub;
    }

    // Update is called once per frame
    void Update()
    {
       if(Lives == 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 300, 50, 100, 100), "" + Lives);
        GUI.Label(new Rect(Screen.width / 2 - 300, 70, 100, 100), "" + coins);
    }
}
