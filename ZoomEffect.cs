using UnityEngine;

public class ZoomAndPanEffect : MonoBehaviour
{
    public float initialZoom = 632.3079f;
    public float finalZoom = 350.0f;
    public float zoomDuration = 2.0f;
    public Vector3 cameraPanOffset = new Vector3(0, 220, 0);
    private float zoomTimer = 0.0f;
    private bool zoomCompleted = false;

    private Camera mainCamera;
    private Vector3 initialCameraPosition;

    public GameObject cartObject;
    private Animator cartAnimator;

    void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
        mainCamera.orthographicSize = initialZoom;
        if (cartObject != null)
        {
            cartAnimator = cartObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("El carrito no ha sido asignado");
        }

        StartZoomAndPanEffect();
    }

    void Update()
    {
        if (!zoomCompleted)
        {
            zoomTimer += Time.deltaTime;
            float currentZoomLevel = Mathf.Lerp(initialZoom, finalZoom, zoomTimer / zoomDuration);
            mainCamera.orthographicSize = currentZoomLevel;
            Vector3 currentCameraPosition = Vector3.Lerp(initialCameraPosition, initialCameraPosition + cameraPanOffset, zoomTimer / zoomDuration);
            mainCamera.transform.position = currentCameraPosition;

            if (zoomTimer >= zoomDuration)
            {
                zoomCompleted = true;
                StartCartAnimation();
            }
        }
    }

    public void StartZoomAndPanEffect()
    {
        zoomTimer = 0.0f;
        zoomCompleted = false;
        mainCamera.orthographicSize = initialZoom;
        mainCamera.transform.position = initialCameraPosition;
    }

    private void StartCartAnimation()
    {
        if (cartObject != null && cartAnimator != null)
        {
            cartAnimator.enabled = true;
        }
        else
        {
            Debug.LogWarning("El carrito o su animator no han sido asignado correctamente");
        }
    }

    private bool IsCameraAtFinalPosition()
    {
        Vector3 currentCameraPosition = mainCamera.transform.position;
        Vector3 finalCameraPosition = initialCameraPosition + cameraPanOffset;
        return Vector3.Distance(currentCameraPosition, finalCameraPosition) < 0.01f;
    }
    public bool IsZoomCompleted()
    {
        return zoomCompleted;
    }
}