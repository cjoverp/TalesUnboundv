using System;
using UnityEngine;

public class LibroController : MonoBehaviour, ICondicionObserver
{
    protected bool isBeingHeld = false;
    protected Vector3 originalPosition;
    public event Action<int> LibrosColocadosActualizados;
    protected static int librosColocados = 0;
    public static bool isPaused = false;

    public Vector2 zonaMinima = new Vector2(788, 865);
    public Vector2 zonaMaxima = new Vector2(1700, 1090);
    public GameObject completedTextObject;
    public GameObject Overlay;

    public LibroManager libroManager;

    public int libroID;

    private bool hasBeenPlaced = false;
    private bool isSelectable = true;

    public float yOffset = 300f;

    protected virtual void Start()
    {
        originalPosition = transform.position;
    }

    public void CondicionCumplida()
    {
        librosColocados++;
        LibrosColocadosActualizados?.Invoke(librosColocados);
        Debug.Log("Aumentando contador: " + (librosColocados));

        if (librosColocados >= TotalLibros())
        {
            completedTextObject.SetActive(true);
            if (Overlay != null)
            {
                Overlay.SetActive(true);
            }
   
            libroManager.DesactivarLibrosYActivarOrdenados();
            librosColocados = 0;
        }

        isSelectable = false;
    }

    protected void Update()
    {
        if (isPaused || !isSelectable) return;

        if (isBeingHeld && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    protected virtual void OnMouseDown()
    {
        if (isPaused || !isSelectable) return;

        if (Input.GetMouseButtonDown(0) && !hasBeenPlaced)
        {
            isBeingHeld = true;
        }
    }

    protected virtual void OnMouseUp()
    {
        if (isPaused || !isSelectable) return;

        isBeingHeld = false;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (mousePos.x >= zonaMinima.x && mousePos.x <= zonaMaxima.x &&
            mousePos.y >= zonaMinima.y && mousePos.y <= zonaMaxima.y)
        {
            int totalSubZonas = 11; 
            float subZonaWidth = (zonaMaxima.x - zonaMinima.x) / totalSubZonas;
            int subZonaIndex = libroID % totalSubZonas;

            float subZonaStartX = zonaMinima.x + subZonaIndex * subZonaWidth;
            float subZonaEndX = subZonaStartX + subZonaWidth;

            if (mousePos.x >= subZonaStartX && mousePos.x <= subZonaEndX)
            {
                float subZonaMiddleX = subZonaStartX + subZonaWidth / 2f;
                transform.position = new Vector3(subZonaMiddleX, originalPosition.y + yOffset, 0);
                hasBeenPlaced = true;
                CondicionCumplida();
                VerificarCompletado();
                originalPosition = transform.position;
            }
            else
            {
                transform.position = originalPosition;
            }
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    protected int TotalLibros()
    {
        return libroManager.libros.Length;
    }

    protected virtual void VerificarCompletado()
    {
        if (librosColocados >= TotalLibros())
        {
            completedTextObject.SetActive(true);
            if (Overlay != null)
            {
                Overlay.SetActive(true);
            }

        }
    }
}
