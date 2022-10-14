using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public MinigameManager minigameManager;

    public int playerId;

    public KeyCode button1;
    public KeyCode button2;
    public KeyCode button3;
    public KeyCode button4;
    

    private void Update()
    {
        if (Input.GetKeyDown(button1))
        {
            minigameManager.PressExternalButton(playerId, 1);
        }
        if (Input.GetKeyDown(button2))
        {
            minigameManager.PressExternalButton(playerId, 2);
        }
        if (Input.GetKeyDown(button3))
        {
            minigameManager.PressExternalButton(playerId, 3);
        }
        if (Input.GetKeyDown(button4))
        {
            minigameManager.PressExternalButton(playerId, 4);
        }
    }
}
