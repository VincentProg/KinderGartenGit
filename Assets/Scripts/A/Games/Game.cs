using System;

public class Game
{
    protected Action<int> onMinigameEnds;

    public virtual void StartGame(Action<int> _onMinigameEnds){}
    public virtual void StopGame(){}
    public virtual void PressButton(int id){}
    public virtual void ReleaseButton(int id){}
    public virtual void Update(){}
}
