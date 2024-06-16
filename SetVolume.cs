using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public AudioManager audioManager;
    public Button unmutedButton; 
    public Button mutedButton;

    private float previousVolume; 

    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if (musicSlider != null)
        {
            musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        }

        if((unmutedButton != null) && (mutedButton!=null))
        {
            unmutedButton.onClick.AddListener(Mute);
            mutedButton.onClick.AddListener(Unmute);
            bool isMuted = PlayerPrefs.GetInt("isMuted", 0) == 1;
            mutedButton.gameObject.SetActive(isMuted);
            unmutedButton.gameObject.SetActive(!isMuted);

            if (isMuted)
            {
                musicSlider.interactable = false;
                mixer.SetFloat("music", -80);
            }

        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;

        if (volume == 0)
        {
            mixer.SetFloat("music", -80); 
            mutedButton.gameObject.SetActive(true);
            unmutedButton.gameObject.SetActive(false);
        }
        else
        {
            mixer.SetFloat("music", Mathf.Log10(volume) * 20);
            mutedButton.gameObject.SetActive(false);
            unmutedButton.gameObject.SetActive(true);
        }

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        if(musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SetMusicVolume();
        }

    }

    private void Mute()
    {
        previousVolume = musicSlider.value;
        mixer.SetFloat("music", -80);
        musicSlider.value = 0; 
        musicSlider.interactable = true; 
        mutedButton.gameObject.SetActive(true);
        unmutedButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("isMuted", 1);
    }

    private void Unmute()
    {
        if (previousVolume == 0)
        {
            previousVolume = 0.001f; 
        }
        mixer.SetFloat("music", Mathf.Log10(previousVolume) * 20);
        musicSlider.value = previousVolume;
        musicSlider.interactable = true;
        mutedButton.gameObject.SetActive(false);
        unmutedButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt("isMuted", 0);
    }
}