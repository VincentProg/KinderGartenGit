using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public MinigameManager minigameManager;

    /*
     * KeyCodes des boutons de pression. De l'intérieur vers l'extérieur
     */
    public KeyCode[] pressionLevelsButton;

    private void Update()
    {
        for (int i = 0; i < pressionLevelsButton.Length; i++)
        {
            if (Input.GetKeyDown(pressionLevelsButton[i]))
            {
                minigameManager.PressButton(i + 1);
            }
            if (Input.GetKeyUp(pressionLevelsButton[i]))
            {
                minigameManager.ReleaseButton(i + 1);
            }
        }
    }
}
