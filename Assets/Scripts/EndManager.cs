using UnityEngine;

public class EndManager : MonoBehaviour
{
    public void End(int _playerIndex)
    {
        Player[] players = FindObjectsOfType<Player>();

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
}
