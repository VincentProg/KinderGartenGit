using System;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    private Menu sceneManager;
    
    private bool isEnd;

    [SerializeField] private KeyCode returnToMenuKey;

    private void Awake()
    {
        sceneManager = FindObjectOfType<Menu>();
    }

    private void Update()
    {
        if (!isEnd)
            return;

        if (Input.GetKeyDown(returnToMenuKey))
        {
            if (sceneManager != null)
                sceneManager.LaunchScene(0);
            else
                Debug.LogError("No <Menu> script, cannot return to menu.");
        }
    }

    public void End(int _playerIndex)
    {
        Player[] players = GameDatasManager.instance.players;

        foreach (Player player in players)
        {
            if (player.PlayerIndex == _playerIndex)
            {
                // Win
                player.playerUI.FadeIn(Color.black, 1f, () =>
                {
                    Transform pTransform = player.transform;
            
                    /*
                     * Disable all player visual components
                     */
                    for (int i = 0; i < pTransform.childCount; ++i)
                    {
                        if (pTransform.GetChild(i).GetComponent<SpriteRenderer>() != null)
                        {
                            pTransform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                    
                    player.playerUI.EndUI(true);
                    player.playerUI.FadeOut(Color.black, 1f, null);
                });
            }
            else
            {
                // Lose
                player.playerUI.FadeIn(Color.black, 1f, () =>
                {
                    Transform pTransform = player.transform;
            
                    /*
                     * Disable all player visual components
                     */
                    for (int i = 0; i < pTransform.childCount; ++i)
                    {
                        if (pTransform.GetChild(i).GetComponent<SpriteRenderer>() != null)
                        {
                            pTransform.GetChild(i).gameObject.SetActive(false);
                        }
                    }
                    
                    player.playerUI.EndUI(false);
                    player.playerUI.FadeOut(Color.black, 1f, null);
                });
            }
        }
    }

    public void PlayersLose()
    {
        Player[] players = GameDatasManager.instance.players;

        foreach (Player player in players)
        {
            player.playerUI.FadeIn(Color.black, 1f, () =>
            {
                Transform pTransform = player.transform;
            
                /*
                 * Disable all player visual components
                 */
                for (int i = 0; i < pTransform.childCount; ++i)
                {
                    if (pTransform.GetChild(i).GetComponent<SpriteRenderer>() != null)
                    {
                        pTransform.GetChild(i).gameObject.SetActive(false);
                    }
                }
                    
                player.playerUI.EndUI(false);
                player.playerUI.FadeOut(Color.black, 1f, null);
            });
        }
    }

    public void HasEnded()
    {
        isEnd = true;
    }
}
