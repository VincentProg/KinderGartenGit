using System;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [HideInInspector] public int PlayerIndex;

    private Action<int> onWinAction;

    private int winStep;
    
    private int steps;
    public int Steps
    {
        get => steps;
        private set => steps = value;
    }

    [SerializeField] private float stepSize;
    public float StepSize
    {
        get => stepSize;
        private set => stepSize = value;
    }

    public void Initialize(int _playerIndex, int _winStep, Action<int> _onWinAction)
    {
        PlayerIndex = _playerIndex;
        winStep = _winStep;
        onWinAction = _onWinAction;
    }

    public void MoveSteps(int _steps)
    {
        if (_steps == 0)
            return;

        steps += _steps;

        if (steps >= winStep)
        {
            onWinAction?.Invoke(PlayerIndex);
        }
    }
}
