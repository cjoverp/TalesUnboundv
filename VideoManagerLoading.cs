using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public SpriteRenderer spriteRenderer;
    public GameObject objectToActivate;
    public GameObject objectToActivate2;

    private void Start()
    {
        Camera.main.backgroundColor = Color.black;

        videoPlayer.enabled = false;
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
        if (objectToActivate2 != null)
        {
            objectToActivate2.SetActive(false);
        }

        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }

        yield return new WaitForSeconds(0.1f);

        videoPlayer.enabled = true; 
        videoPlayer.Play();
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        if (objectToActivate2 != null)
        {
            objectToActivate2.SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);

        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
        }
    }
}

