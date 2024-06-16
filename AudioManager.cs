using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip LogoyDia;
    public AudioClip DiaBucle;
    public AudioClip soundToPlayOnStart;
    public Button targetButton;
    public GameObject targetImage;
    public Button stopButton;

    private bool isMusicPlaying = false;

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName != "MenuInicial" && currentSceneName != "MenuInicial2")
        {
            musicSource.clip = background;
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
                isMusicPlaying = true;
            }
        }
        if (soundToPlayOnStart != null && targetButton != null && targetImage != null)
        {
            PlaySoundWithDelayAndActivateObjects(soundToPlayOnStart, targetButton, targetImage, 3.0f);
        }
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(StopLoopingSound);
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

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
        isMusicPlaying = true;
    }

    public void PauseAllAudio()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }
        if (SFXSource.isPlaying)
        {
            SFXSource.Pause();
        }
    }

    public void ResumeAllAudio()
    {
        if (musicSource.clip != null)
        {
            musicSource.UnPause();
        }
        if (SFXSource.clip != null)
        {
            SFXSource.UnPause();
        }
    }

    public void PlaySoundWithDelayAndActivateObjects(AudioClip clip, Button targetButton, GameObject targetImage, float delay)
    {
        StartCoroutine(PlaySoundAndActivateObjectsCoroutine(clip, targetButton, targetImage, delay));
    }

    private IEnumerator PlaySoundAndActivateObjectsCoroutine(AudioClip clip, Button targetButton, GameObject targetImage, float delay)
    {
        yield return new WaitForSeconds(delay);
        SFXSource.clip = clip;
        SFXSource.loop = true; 
        SFXSource.Play();

        yield return new WaitForSeconds(clip.length);
        targetButton.gameObject.SetActive(true);
        targetImage.SetActive(true);
    }

    public void StopLoopingSound()
    {
        if (SFXSource.isPlaying)
        {
            SFXSource.Stop();
            SFXSource.loop = false; 
        }
    }
}
