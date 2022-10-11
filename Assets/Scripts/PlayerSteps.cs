using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    [HideInInspector] public int PlayerIndex;
    
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

    private void Initialize(int _playerIndex)
    {
        PlayerIndex = _playerIndex;
    }

    public void MoveSteps(int _steps)
    {
        if (_steps == 0)
            return;

        steps += _steps;
    }
}
