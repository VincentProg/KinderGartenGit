using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject loseObject;
    [Space] 
    [SerializeField] private Image colorTransitionImage;

    private Coroutine fadeCoroutine;
    
    public delegate void OnFadeEnd();
    private OnFadeEnd onFadeInEnd;
    private OnFadeEnd onFadeOutEnd;
    
    public void EndUI(bool _isWin)
    {
        winObject.SetActive(_isWin);
        loseObject.SetActive(!_isWin);
    }

    public void FadeIn(Color _fadeColor, float _time, OnFadeEnd _onFadeEnd)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(Fade(true, _time, _fadeColor));
    }

    public void FadeOut(Color _fadeColor, float _time, OnFadeEnd _onFadeEnd)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(Fade(false, _time, _fadeColor));
    }

    private IEnumerator Fade(bool _isFadingIn, float _time, Color _imageColor)
    {
        float t = 0f;

        float startA = _isFadingIn ? 0f : 1f;
        float endA = 1 - startA;

        while (t <= 1f)
        {
            _imageColor.a = Mathf.Lerp(startA, endA, t);

            colorTransitionImage.color = _imageColor;
            
            t += Time.deltaTime / _time;

            yield return null;
        }
        
        if (_isFadingIn)
            onFadeInEnd?.Invoke();
        else
            onFadeOutEnd?.Invoke();
    }
}
