using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameButton : Game
{
    private int chosenButton1;
    private int chosenButton2;

    private bool validatedB1P1;
    private bool validatedB2P1;
    private bool validatedB1P2;
    private bool validatedB2P2;
    
    public override void StartGame(Action<int> _onMinigameEnds)
    {
        onMinigameEnds = _onMinigameEnds;

        chosenButton1 = Random.Range(1, 3);
        chosenButton2 = 3;
        
        validatedB1P1 = false;
        validatedB2P1 = false;
        validatedB1P2 = false;
        validatedB2P2 = false;

        String p1b1 = "";
        String p2b1 = "";
        String p1b2 = "";
        String p2b2 = "";
        if (chosenButton1 == 1)
        {
            p1b1 = PlayersManager.instance.ButtonManagerP1.colorB1;
            p2b1 = PlayersManager.instance.ButtonManagerP2.colorB1;
        }
        else
        if (chosenButton1 == 2)
        {
            p1b1 = PlayersManager.instance.ButtonManagerP1.colorB2;
            p2b1 = PlayersManager.instance.ButtonManagerP2.colorB2;
        }
        else
        if (chosenButton1 == 3)
        {
            p1b1 = PlayersManager.instance.ButtonManagerP1.colorB3;
            p2b1 = PlayersManager.instance.ButtonManagerP2.colorB3;
        }
        if (chosenButton2 == 1)
        {
            p1b2 = PlayersManager.instance.ButtonManagerP1.colorB1;
            p2b2 = PlayersManager.instance.ButtonManagerP2.colorB1;
        }
        else
        if (chosenButton2 == 2)
        {
            p1b2 = PlayersManager.instance.ButtonManagerP1.colorB2;
            p2b2 = PlayersManager.instance.ButtonManagerP2.colorB2;
        }
        else
        if (chosenButton2 == 3)
        {
            p1b2 = PlayersManager.instance.ButtonManagerP1.colorB3;
            p2b2 = PlayersManager.instance.ButtonManagerP2.colorB3;
        }
        
        PopupManager.instance.showPopup("Appuyez sur les boutons " + p1b1 + " et " + p1b2, Color.white, new Vector2(0,100), 1);
        PopupManager.instance.showPopup("Appuyez sur les boutons " + p2b1 + " et " + p2b2, Color.white, new Vector2(0,100), 2);
    }

    public override void PressExternalButton(int playerId, int id)
    {
        if (id == chosenButton1)
        {
            if (playerId == 1)
            {
                validatedB1P1 = true;
            }
            else
            {
                validatedB1P2 = true;
            }
        }
        else if (id == chosenButton2)
        {
            if (playerId == 1)
            {
                validatedB2P1 = true;
            }
            else
            {
                validatedB2P2 = true;
            }
        }

        if (validatedB1P1 && validatedB2P1)
        {
            PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),1);
            PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),2);

            onMinigameEnds?.Invoke(1);
        }
        else if (validatedB1P2 && validatedB2P2)
        {
            
            PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),2);
            PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),1);
            onMinigameEnds?.Invoke(2);
        }
    }
}
