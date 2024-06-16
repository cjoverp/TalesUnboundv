using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    void Start()
    {
        ZoomAndPanEffect zoomAndPanEffect = FindObjectOfType<ZoomAndPanEffect>();
        if (zoomAndPanEffect != null)
        {
            zoomAndPanEffect.StartZoomAndPanEffect();
        }
    }
}
