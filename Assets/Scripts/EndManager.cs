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

        if (Input.GetKeyDown(returnToMenuKey) && sceneManager != null)
        {
            sceneManager.LaunchScene(0);
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
                    player.playerUI.FadeOut(Color.black, 1f, null);
                    player.playerUI.EndUI(true);
                });
            }
            else
            {
                // Lose
                player.playerUI.FadeIn(Color.black, 1f, () =>
                {
                    player.playerUI.FadeOut(Color.black, 1f, null);
                    player.playerUI.EndUI(false);
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
                player.playerUI.FadeOut(Color.black, 1f, null);
                player.playerUI.EndUI(false);
            });
        }
    }

    public void HasEnded()
    {
        isEnd = true;
    }
}
