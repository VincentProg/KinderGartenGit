using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public TMP_Text textP1;
    public TMP_Text textP2;

    public static PopupManager instance;

    private Coroutine routineP1;
    private Coroutine routineP2;

    public PopupManager()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Awake()
    {
        textP1.gameObject.SetActive(false);
        textP2.gameObject.SetActive(false);
    }

    public void showPopup(String textToDisplay, Color color, Vector2 position, int playerId)
    {
        if (playerId == 1)
        {
            if (routineP1 != null) StopCoroutine(routineP1);

            textP1.text = textToDisplay;
            textP1.color = color;
            textP1.transform.localPosition = position;

            textP1.gameObject.SetActive(true);
        }
        else if (playerId == 2)
        {
            if (routineP2 != null) StopCoroutine(routineP2);

            textP2.text = textToDisplay;
            textP2.color = color;
            textP2.transform.localPosition = position;

            textP2.gameObject.SetActive(true);
        }
    }
    public void showPopup(String textToDisplay, Color color, Vector2 position, int playerId, float durationInSeconds)
    {
        showPopup(textToDisplay, color, position, playerId);
        if(playerId == 1)
            routineP1 = StartCoroutine(DeactivateText(playerId, durationInSeconds));
        else if(playerId == 2)
            routineP2 = StartCoroutine(DeactivateText(playerId, durationInSeconds));
    }

    IEnumerator DeactivateText(int playerId, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(playerId == 1)
            textP1.gameObject.SetActive(false);
        else if(playerId == 2)
            textP2.gameObject.SetActive(false);
    }
}
