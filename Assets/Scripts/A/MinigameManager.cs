using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinigameManager : MonoBehaviour
{
    
    public enum MG
    {
        TETE,
        MOU,
        LACHER,
        NONE
    }

    public float randomGameDelay = 5f;
    [Range(0f,1f)]
    public float chanceToStartGame = .5f;

    private Game currentMG;
    private Game gameTete = new GameTete();
    private Game gameMou = new GameMou();
    private Game gameLacher = new GameLacher();

    private float timer = 0;


    private void Start()
    {
        StartMinigame(MG.TETE);
    }

    private void Update()
    {
        if (currentMG == null)
        {
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                timer -= 5f;
                if (Random.Range(0, 1) < randomGameDelay)
                {
                    StartRandomGame();
                }
            }
        }
        else
        {
            currentMG.Update();
        }
    }

    public void StartRandomGame()
    {
        /*  */
        if (currentMG == null)
        {
            StartMinigame(MG.TETE);
            return;
        }
    }
    
    public void StartMinigame(MG game)
    {
        Debug.Log(game + " MG Started");
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


    public void Decapitate()
    {
        Debug.Log("deth");
    }

}
