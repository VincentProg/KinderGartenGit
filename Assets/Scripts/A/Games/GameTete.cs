using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTete : Game
{
    private bool _P1Started;
    private bool _P2Started;

    private float timeP1;
    private float timeP2;

    private float timer;

    private bool _gameStarted;

    public override void StartGame(Action<int> _onMinigameEnds)
    {
        timer = 0;
        timeP1 = 0;
        timeP2 = 0;
        _P1Started = false;
        _P2Started = false;
        _gameStarted = true;
        
        PopupManager.instance.showPopup("Tirez la laisse au maximum ! Le premier à lacher dans les 5 prochaines secondes a perdu.", Color.white, new Vector2(
            0, 100), 1); 
        PopupManager.instance.showPopup("Tirez la laisse au maximum ! Le premier à lacher dans les 5 prochaines secondes a perdu.", Color.white, new Vector2(
            0, 100), 2);
    }

    public override void Update()
    {
        if(_gameStarted)
        {
            if (_P1Started && _P2Started)
            {
                timer += Time.deltaTime;
                if (timer <= 5f)
                {
                    if (PlayersManager.instance.GetPressionLevel(1) != 0)
                    {
                        PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),1,5f);
                        PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),2,5f);
                        _gameStarted = false;
                        
                        onMinigameEnds?.Invoke(1);
                    }

                    if (PlayersManager.instance.GetPressionLevel(2) != 0)
                    {
                        PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),1,5f);
                        PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),2,5f);
                        _gameStarted = false;
                        
                        onMinigameEnds?.Invoke(2);
                    }
                }
                else
                {
                    PopupManager.instance.showPopup("5 secondes dépassées, vous avez tous les deux perdu !", Color.white, new Vector2(0, 100),1,5f);
                    PopupManager.instance.showPopup("5 secondes dépassées, vous avez tous les deux perdu !", Color.white, new Vector2(0, 100),2,5f);
                    _gameStarted = false;
                    
                    onMinigameEnds?.Invoke(-1);
                }
                Debug.Log(timer);
            }
            else
            {
                _P1Started = PlayersManager.instance.GetPressionLevel(1) == 0;
                _P2Started = PlayersManager.instance.GetPressionLevel(2) == 0;
                timer = 0;
            }
        }
    }
}
