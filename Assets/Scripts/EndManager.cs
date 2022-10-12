using UnityEngine;

public class EndManager : MonoBehaviour
{
    public void End(int _playerIndex)
    {
        Player[] players = GameDatasManager.instance.players;

        foreach (Player player in players)
        {
            if (player.PlayerIndex == _playerIndex)
            {
                // Win
                player.playerUI.EndUI(true);
            }
            else
            {
                // Lose
                player.playerUI.EndUI(false);
            }
        }
    }

    public void PlayersLose()
    {
        Player[] players = GameDatasManager.instance.players;

        foreach (Player player in players)
        {
            player.playerUI.EndUI(false);
        }
    }
}
