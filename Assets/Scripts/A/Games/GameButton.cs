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
        chosenButton2 = Random.Range(3, 5);
        
        validatedB1P1 = false;
        validatedB2P1 = false;
        validatedB1P2 = false;
        validatedB2P2 = false;
        
        PopupManager.instance.showPopup("Appuyez sur les boutons " + chosenButton1 + " et " + chosenButton2, Color.white, new Vector2(0,100), 1);
        PopupManager.instance.showPopup("Appuyez sur les boutons " + chosenButton1 + " et " + chosenButton2, Color.white, new Vector2(0,100), 2);
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
