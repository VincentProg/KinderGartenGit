using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;
    
    public MinigameManager MGManager;
    
    public ButtonManager buttonManagerP1;
    public ButtonManager buttonManagerP2;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        buttonManagerP1.minigameManager = MGManager;
        buttonManagerP2.minigameManager = MGManager;
    }

    public int GetPressionLevel(int playerId)
    {
        if (playerId == 1)
        {
            return buttonManagerP1.pressionLevel;
        }
        if (playerId == 2)
        {
            return buttonManagerP2.pressionLevel;
        }

        return 0;
    }
}
