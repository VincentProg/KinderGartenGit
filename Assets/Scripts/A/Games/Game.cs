using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public virtual void StartGame(){}
    public virtual void StopGame(){}
    public virtual void PressButton(int id){}
    public virtual void ReleaseButton(int id){}
}
