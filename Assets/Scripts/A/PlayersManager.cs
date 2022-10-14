using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;

    public MinigameManager MGManager;

    public ButtonManager ButtonManagerP1;
    public ButtonManager ButtonManagerP2;

    public Player P1;
    public Player P2;

    public Leash leash;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    public int GetPressionLevel(int playerId)
    {
        if (playerId == 1)
        {
            return P1.intensityPull;
        }
        if (playerId == 2)
        {
            return P2.intensityPull;
        }

        return 0;
    }

    public void setPlayerAnim(int playerID, bool pullLeash)
    {
        //if (playerID == 1)
        //{
        //    if(pullLeash) P1.PullLeash();
        //    else P1.Relax();
        //}
        //else if (playerID == 2)
        //{
        //    if(pullLeash) P2.PullLeash();
        //    else P2.Relax();
        //}
    }
}
