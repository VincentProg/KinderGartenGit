using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public enum MG
    {
        TETE,
        MOU,
        LACHER,
        NONE
    }

    private Game currentMG;
    private Game gameTete = new GameTete();
    private Game gameMou = new GameMou();
    private Game gameLacher = new GameLacher();
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        StartMinigame(MG.TETE);
    }

    private void Update()
    {
        if (currentMG != null)
        {
            currentMG.Update();
        }
    }

    public void StartMinigame(MG game)
    {
        if (currentMG != null)
            currentMG.StopGame();
        switch (game)
        {
            case MG.TETE:
                currentMG = gameTete;
                break;
            case MG.MOU:
                currentMG = gameMou;
                break;
            case MG.LACHER:
                currentMG = gameLacher;
                break;
            case MG.NONE:
                currentMG = null;
                return;
        }
        currentMG.StartGame();
    }

    public void PressButton(int id)
    {
        if(currentMG != null)
            currentMG.PressButton(id);
    }
    public void ReleaseButton(int id)
    {
        if(currentMG != null)
            currentMG.ReleaseButton(id);
    }

}
