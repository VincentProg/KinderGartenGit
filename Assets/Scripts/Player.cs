using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerIndex = -1;
    public int PlayerIndex
    {
        get => playerIndex;
        private set
        {
            if (playerIndex < 0 && value >= 0)
                playerIndex = value;
        }
    }

    public PlayerSteps playerSteps { get; private set; }
    public PlayerUI playerUI { get; private set; }

    [SerializeField] private Camera playerCamera;

    private void Awake()
    {
        playerSteps = GetComponent<PlayerSteps>();
        playerUI = GetComponent<PlayerUI>();
    }

    private void Start()
    {
        playerSteps.Initialize(playerIndex, GameDatasManager.instance.WinStep, GameDatasManager.instance.endManager.End);
    }
}
