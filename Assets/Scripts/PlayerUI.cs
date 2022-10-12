using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject loseObject;

    public void EndUI(bool _isWin)
    {
        winObject.SetActive(_isWin);
        loseObject.SetActive(!_isWin);
    }
}
