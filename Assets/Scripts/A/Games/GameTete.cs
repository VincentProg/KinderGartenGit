using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTete : Game
{
    private bool _P1Started;
    private bool _P2Started;

    private float timeP1;
    private float timeP2;

    private float timer;

    private bool _gameStarted;
    private bool _dualStarted;

    public override void StartGame()
    {
        timer = 0;
        timeP1 = 0;
        timeP2 = 0;
        _P1Started = false;
        _P2Started = false;
        _gameStarted = true;
        _dualStarted = false;
        
        PopupManager.instance.showPopup("Tirez la laisse au maximum ! Le premier à lacher dans les 5 prochaines secondes a perdu.", Color.white, new Vector2(
            0, 100));
    }

    public override void Update()
    {
        if(_gameStarted)
        {
            if (_P1Started && _P2Started)
            {
                _dualStarted = true;
                timer += Time.deltaTime;
                if (timer <= 5f)
                {
                    if (PlayersManager.instance.GetPressionLevel(1) != 0)
                    {
                        PopupManager.instance.showPopup("Player 1 Lost", Color.white, new Vector2(0, 100), 5f);
                        _gameStarted = false;
                    }

                    if (PlayersManager.instance.GetPressionLevel(2) != 0)
                    {
                        PopupManager.instance.showPopup("Player 2 Lost", Color.white, new Vector2(0, 100), 5f);
                        _gameStarted = false;
                    }
                }
                else
                {
                    Debug.Log("Both lost");
                    _gameStarted = false;
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
