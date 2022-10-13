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
    private Animator anim;

    [SerializeField] private Camera playerCamera;

    private void Awake()
    {
        playerSteps = GetComponent<PlayerSteps>();
        playerUI = GetComponent<PlayerUI>();
    }

    private void Start()
    {
        playerSteps.Initialize(playerIndex, GameDatasManager.instance.WinStep, GameDatasManager.instance.endManager.End);
        anim = GetComponent<Animator>();
    }

    [ContextMenu("AddStep")]
    private void AddStep()
    {
        
        playerSteps.MoveSteps(1);
    }
    
    public void PullLeash()
    {
        anim.SetBool("isPulling", true);
    }

    public void Relax()
    {
        anim.SetBool("isPulling", false);
    }
}
