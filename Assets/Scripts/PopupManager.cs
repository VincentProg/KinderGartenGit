using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public TMP_Text text;

    public static PopupManager instance;

    private Coroutine routine;

    public PopupManager()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    public void showPopup(String textToDisplay, Color color, Vector2 position)
    {
        if (routine != null) StopCoroutine(routine);
        text.text = textToDisplay;
        text.color = color;
        text.transform.localPosition = position;

        text.gameObject.SetActive(true);
    }
    public void showPopup(String textToDisplay, Color color, Vector2 position, float durationInSeconds)
    {
        showPopup(textToDisplay, color, position);
        routine = StartCoroutine(DeactivateText(durationInSeconds));
    }

    IEnumerator DeactivateText(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        text.gameObject.SetActive(false);
    }
}
