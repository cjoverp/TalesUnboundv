using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;

    private bool isMusicPlaying = false; 

    private void Start()
    {
        musicSource.clip = background;
        if (!musicSource.isPlaying)
        {
            musicSource.Play();
            isMusicPlaying = true;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public bool IsMusicPlaying()
    {
        return isMusicPlaying;
    }
}
