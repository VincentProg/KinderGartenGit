using System;
using UnityEngine;

public class GameDatasManager : MonoBehaviour
{
    public static GameDatasManager instance;
    
    public EndManager endManager { get; private set; }
    
    public Player[] players { get; private set; }
    public Kid kid { get; private set; }

    [SerializeField] private int winStep;
    public int WinStep
    {
        get => winStep;
        private set => winStep = value;
    }

    private void Awake()
    {
        instance = this;
        
        endManager = FindObjectOfType<EndManager>();
        
        players = FindObjectsOfType<Player>();
        kid = FindObjectOfType<Kid>();
    }
}
