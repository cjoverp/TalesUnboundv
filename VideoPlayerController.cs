using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer firstVideoPlayer; 
    public VideoPlayer secondVideoPlayer; 

    void Start()
    {
        if (firstVideoPlayer != null)
        {
            firstVideoPlayer.loopPointReached += OnFirstVideoEnd;
        }

        if (secondVideoPlayer == null)
        {
            Debug.LogWarning("No se ha asignado el segundo reproductor de video.");
        }
    }

    void OnFirstVideoEnd(VideoPlayer vp)
    {
        if (secondVideoPlayer != null)
        {
            secondVideoPlayer.Play(); 
        }

        if (firstVideoPlayer != null)
        {
            firstVideoPlayer.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el primer reproductor de video.");
        }
    }

}
