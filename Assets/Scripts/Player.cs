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

    private PlayerSteps playerSteps;
        
    [SerializeField] private Kid kid;
    public Kid Kid
    {
        get => kid;
        private set => kid = value;
    }

    private void Awake()
    {
        playerSteps = GetComponent<PlayerSteps>();
    }

    private void Start()
    {
        kid.Initialize(playerIndex);
    }

    /*
     * DEBUG
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerSteps.MoveSteps(-1);
            kid.MoveKid(-1, playerSteps.StepSize, null);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerSteps.MoveSteps(1);
            kid.MoveKid(1, playerSteps.StepSize, null);
        }
    }
}
