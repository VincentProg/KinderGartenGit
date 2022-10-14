//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ButtonManager : MonoBehaviour
//{
//    public MinigameManager minigameManager;

//    public int playerId;
    
//    /*
//     * Le niveau de pression correspond au nombre de boutons pressés. Si 3 boutons au repos, pressionLevel = 3
//     */
//    public int pressionLevel = 2;
//    private int _lastPressionLevel = 2;
    

//    /*
//     * KeyCodes des boutons de pression. De l'intérieur vers l'extérieur
//     */
//    public KeyCode[] pressionLevelsButton;

//    private void Start()
//    {
//        for (var i = 0; i < pressionLevelsButton.Length; i++)
//        {
//            if (Input.GetKey(pressionLevelsButton[i]))
//            {
//                pressionLevel = i + 1;
//            }
//        }
//    }

//    private void Update()
//    {
//        if (_lastPressionLevel > 0)
//        {
//            PlayersManager.instance.setPlayerAnim(playerId, true);
//            Debug.Log(_lastPressionLevel);
//        }
//        else
//        {
//            PlayersManager.instance.setPlayerAnim(playerId, false);
//            Debug.Log(_lastPressionLevel);
//        }
//        for (int i = 0; i < pressionLevelsButton.Length; i++)
//        {
//            if (Input.GetKeyDown(pressionLevelsButton[i]))
//            {
//                minigameManager.PressButton(i + 1);
//                pressionLevel = i + 1;
//                Debug.Log(pressionLevel);
//            }
//            if (Input.GetKeyUp(pressionLevelsButton[i]))
//            {
//                minigameManager.ReleaseButton(i);
//                pressionLevel = i;
//                Debug.Log(pressionLevel);
//            }
//        }

//        _lastPressionLevel = pressionLevel;
//    }
//}
