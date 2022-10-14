using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTete : Game
{

    private float timeP1;
    private float timeP2;

    private float timer;

    private bool _gameStarted;
    private bool _isEnded;

    public override void StartGame(Action<int> _onMinigameEnds)
    {
        timer = 0;
        timeP1 = 0;
        timeP2 = 0;    
        PopupManager.instance.showPopup("Tirez la laisse au maximum ! Le premier à lacher dans les 5 prochaines secondes a perdu.", Color.white, new Vector2(
            0, 100), 1); 
        PopupManager.instance.showPopup("Tirez la laisse au maximum ! Le premier à lacher dans les 5 prochaines secondes a perdu.", Color.white, new Vector2(
            0, 100), 2);
    }

    public override void Update()
    {
        if (_isEnded) return;

        if (!_gameStarted)
        {
            Debug.Log(PlayersManager.instance.GetPressionLevel(1) + " " + PlayersManager.instance.GetPressionLevel(2));
            if (PlayersManager.instance.GetPressionLevel(1) == 2 && PlayersManager.instance.GetPressionLevel(2) == 2)
            {
                _gameStarted = true;
            }
        }


        if(_gameStarted)
        {
                timer += Time.deltaTime;
                if (timer <= 5f)
                {
                    PopupManager.instance.showPopup("" + ((int)timer), Color.white, new Vector2(0, 100), 1);
                    PopupManager.instance.showPopup("" + ((int)timer), Color.white, new Vector2(0, 100), 2);
                    if (PlayersManager.instance.GetPressionLevel(1) != 2)
                    {
                        PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),1);
                        PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),2);
                        _gameStarted = false;
                        _isEnded = true;
                        
                        onMinigameEnds?.Invoke(1);
                    }

                    if (PlayersManager.instance.GetPressionLevel(2) != 2)
                    {
                        PopupManager.instance.showPopup("You Won !", Color.white, new Vector2(0, 100),1);
                        PopupManager.instance.showPopup("You lost !", Color.white, new Vector2(0, 100),2);
                        _gameStarted = false;
                        _isEnded = true;


                        onMinigameEnds?.Invoke(2);
                    }
                }
                else
                {
                    PopupManager.instance.showPopup("5 secondes dépassées, vous avez tous les deux perdu !", Color.white, new Vector2(0, 100),1,5f);
                    PopupManager.instance.showPopup("5 secondes dépassées, vous avez tous les deux perdu !", Color.white, new Vector2(0, 100),2,5f);
                    _gameStarted = false;
                    _isEnded = true;


                    onMinigameEnds?.Invoke(-1);
                }
                Debug.Log(timer);
            }
        }
    }
