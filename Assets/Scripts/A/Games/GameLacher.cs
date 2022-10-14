using System;
using UnityEngine;

public class GameLacher : Game
{
    public override void StartGame(Action<int> _onMinigameEnds)
    {
        onMinigameEnds = _onMinigameEnds;
        Debug.Log("oui");
    }
    
    public override void PressButton(int id)
    {
        Debug.Log(id);
    }
    
    public override void ReleaseButton(int id)
    {
        Debug.Log(id);
    }
}
