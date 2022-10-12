using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MinigameManager.instance.PressButton(1);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MinigameManager.instance.PressButton(2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MinigameManager.instance.PressButton(3);
        }
    }
}
