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

    Leash leash;

    public int intensityPull;

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
        leash = FindObjectOfType<Leash>();
    }

    [ContextMenu("AddStep")]
    private void AddStep()
    {
        
        playerSteps.MoveSteps(1);
    }
    
    public void PullLeash()
    {
        anim.SetBool("isPulling", true);
        intensityPull++;
        Debug.Log("Pull " + intensityPull);

        leash.ChangeState(playerIndex, intensityPull);
    }

    public void Relax()
    {
        intensityPull--;
        if (intensityPull < 0) intensityPull = 0;
        leash.ChangeState(playerIndex, intensityPull);
        Debug.Log("Relax " + intensityPull);

        if (intensityPull <= 0)
        anim.SetBool("isPulling", false);
    }
}
