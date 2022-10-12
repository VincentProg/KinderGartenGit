using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLacher : Game
{
    public override void StartGame()
    {
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
