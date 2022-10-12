using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance;
    
    public MinigameManager managerP1;
    public MinigameManager managerP2;
    
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
        buttonManagerP1.minigameManager = managerP1;
        buttonManagerP2.minigameManager = managerP2;
    }
}
