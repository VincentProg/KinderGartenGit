using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource, soundSource;

    public void PlaySound(AudioClip _clip)
    {
        soundSource.PlayOneShot(_clip);
    }
    public void PlayMusic(AudioClip _clip)
    {
        musicSource.PlayOneShot(_clip);
    }
    
}
