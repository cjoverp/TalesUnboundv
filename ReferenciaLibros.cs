using UnityEngine;

public class ReferenciaLibros : MonoBehaviour
{
    public GameObject RefImage;
    public float DurationImage = 3.0f;
    private bool ActiveImage = false;
    private float InitialTime;
    private ZoomAndPanEffect zoomScript;

    void Start()
    {
        zoomScript = FindObjectOfType<ZoomAndPanEffect>();
        RefImage.SetActive(false);
    }

    void Update()
    {
        if (zoomScript != null && zoomScript.IsZoomCompleted())
        {
            if (!ActiveImage)
            {
                RefImage.SetActive(true);
                InitialTime = Time.time;
                ActiveImage = true;
            }

            if (ActiveImage && Time.time - InitialTime  >= DurationImage)
            {
                RefImage.SetActive(false);
                ActiveImage = false;
            }
        }
    }
}
