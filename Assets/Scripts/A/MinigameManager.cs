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
        BUTTON,
        NONE
    }

    public float randomGameDelay = 5f;
    [Range(0f,1f)]
    public float chanceToStartGame = .5f;

    private Game currentMG;
    private Game gameTete = new GameTete();
    private Game gameButton = new GameButton();

    private float timer = 0;

    private void Update()
    {
        if (GameDatasManager.instance.endManager.HasEnded)
            return;
        
        if (currentMG == null)
        {
            timer += Time.deltaTime;
            if (timer >= randomGameDelay)
            {
                timer -= randomGameDelay;
                if (Random.Range(0, 1) < chanceToStartGame)
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
        float random = Random.Range(0f, 1f);
        Debug.LogWarning(random);

        if (random < .5f)
        {
            StartMinigame(MG.TETE);
        }
        else
        {
            StartMinigame(MG.BUTTON);
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
            case MG.BUTTON:
                currentMG = gameButton;
                break;
            case MG.NONE:
                currentMG = null;
                return;
        }
        currentMG.StartGame(EndMinigame);
    }

    private void EndMinigame(int _winnerPlayerIndex)
    {
        Player winnerPlayer = null;
        
        foreach (Player player in GameDatasManager.instance.players)
        {
            if (player.PlayerIndex == _winnerPlayerIndex)
            {
                winnerPlayer = player;
            }
            else
            {
                player.playerSteps.MoveSteps(-1);
            }
        }

        if (winnerPlayer != null)
        {
            GameDatasManager.instance.kid.MoveKid(1,
                winnerPlayer.PlayerIndex == 1 ? -winnerPlayer.playerSteps.StepSize : winnerPlayer.playerSteps.StepSize,
                () =>
                {
                    winnerPlayer.playerSteps.MoveSteps(1);
                    this.currentMG = null;
                });
        }
        else
        {
            // Both lose, kid death
            Decapitate();
        }
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

    public void PressExternalButton(int playerId, int id)
    {
        Debug.LogWarning(playerId + " " + id);
        if(currentMG != null)
            currentMG.PressExternalButton(playerId, id);
    }


    public void Decapitate()
    {
        Debug.Log("death");
        GameDatasManager.instance.kid.StartChocking();
        GameDatasManager.instance.endManager.PlayersLose();
    }

}
