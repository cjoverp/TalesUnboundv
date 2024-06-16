using UnityEngine;
using UnityEngine.SceneManagement;


public class RotarYArrastrarObjeto : MonoBehaviour
{
    public GameObject objetoInteractuable;
    public GameObject objetoActivarAlSoltar;
    public GameObject objetoActivarAlSoltar2; 
    public GameObject objetoDesactivarAlSoltar; 
    public GameObject objetoDesactivarAlSoltar2;
    public GameObject objetoDesactivarAlSoltar3;
    public GameObject objetoDesactivarAlSoltar4;
    public GameObject objetoDesactivarAlSoltar5;
    public GameObject Overlay; 
    public GameObject objetoActivarZona2; 
    public GameObject cruzRojaZona2;
    private Quaternion rotacionInicial;
    private Vector3 posicionOriginal;
    private bool estaSiendoSeleccionado = false;
    private bool estaSiendoArrastrado = false;
    private bool dontMove = false; 
    private bool soltadoEnZona = false; 
    public CargarEscena cargadorEscena;

    private string escenaActual;

    private void Start()
    {
        rotacionInicial = transform.rotation;
        posicionOriginal = transform.position;
        cargadorEscena = FindObjectOfType<CargarEscena>();
        escenaActual = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (estaSiendoArrastrado)
        {
            Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (CheckFirstZone(posicionMouse))
            {
                if (objetoActivarAlSoltar != null)
                {
                    objetoActivarAlSoltar.SetActive(true);
                    Debug.Log("Estamos dentro de la primera zona");
                }
            }
            else
            {
                if (objetoActivarAlSoltar != null)
                {
                    objetoActivarAlSoltar.SetActive(false);
                }
            }

            if (CheckSecondZone(posicionMouse))
            {
                if (cruzRojaZona2 != null)
                {
                    cruzRojaZona2.SetActive(true);
                    Debug.Log("Estamos dentro de la segunda zona");
                }
            }
            else
            {
                if (cruzRojaZona2 != null)
                {
                    cruzRojaZona2.SetActive(false);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (objetoInteractuable != null && objetoInteractuable.activeSelf && !dontMove)
        {
            transform.Rotate(Vector3.forward, -45f);
            estaSiendoSeleccionado = true;
            estaSiendoArrastrado = true;
        }
    }

    private void OnMouseUp()
    {
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (CheckFirstZone(posicionMouse))
        {
            HandleFirstZone();
        }
        else if (CheckSecondZone(posicionMouse))
        {
            HandleSecondZone();
        }

        RestaurarRotacionYPosicionOriginal();
        estaSiendoArrastrado = false;
    }

    private bool CheckFirstZone(Vector3 posicionMouse)
    {
        return posicionMouse.x >= 1079f && posicionMouse.x <= 1230f && posicionMouse.y >= 756f && posicionMouse.y <= 905f;
    }

    private bool CheckSecondZone(Vector3 posicionMouse)
    {
        return posicionMouse.x >= 1360f && posicionMouse.x <= 1516f && posicionMouse.y >= 756f && posicionMouse.y <= 905f;
    }

    private void HandleFirstZone()
    {
        if (estaSiendoSeleccionado)
        {
            bool accionCorrecta = (escenaActual == "MinijuegoNochePt2" || escenaActual == "NocheLvl3Pt2");
            if (accionCorrecta)
            {
                if (objetoActivarAlSoltar2 != null)
                {
                    objetoActivarAlSoltar2.SetActive(true);
                    Debug.Log("Acción correcta en la primera zona.");
                }
                if (Overlay != null)
                {
                    Overlay.SetActive(true);
                }
            }
            else
            {
                if (objetoActivarZona2 != null)
                {
                    objetoActivarZona2.SetActive(true);
                    Invoke("DesactivarObjetoActivarZona2", 2f);
                    if (Overlay != null)
                    {
                        Overlay.SetActive(true);
                    }
                }
            }

            if (accionCorrecta)
            {
                if (escenaActual == "MinijuegoNochePt2")
                {
                    cargadorEscena.CargarNivelNocheLvl2();
                } else if (escenaActual == "NocheLvl3Pt2")
                {
                    cargadorEscena.CargarEscenaFinalPruebaDelay();
                }
            }
        }
    }

    private void HandleSecondZone()
    {
        if (estaSiendoSeleccionado)
        {
            bool accionCorrecta = (escenaActual == "NocheLvl2Pt2");
            if (accionCorrecta)
            {
                if (objetoActivarAlSoltar2 != null)
                {
                    objetoActivarAlSoltar2.SetActive(true);
                    Debug.Log("Acción correcta dentro de la segunda zona.");
                }
                if (Overlay != null)
                {
                    Overlay.SetActive(true);
                }
            }
            else
            {
                if (objetoActivarZona2 != null)
                {
                    objetoActivarZona2.SetActive(true);
                    Invoke("DesactivarObjetoActivarZona2", 2f);
                    Debug.Log("Acción incorrecta dentro de la segunda zona.");
                }
                if (Overlay != null)
                {
                    Overlay.SetActive(true);
                }
            }

            if (accionCorrecta)
            {
                if (escenaActual == "NocheLvl2Pt2")
                {
                    cargadorEscena.CargarNivelNocheLvl3Delay();
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        if (estaSiendoSeleccionado && objetoInteractuable != null && objetoInteractuable.activeSelf && !dontMove)
        {
            estaSiendoArrastrado = true;
            Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionMouse.z = 0f;
            transform.position = posicionMouse;
        }
    }

    private void RestaurarRotacionYPosicionOriginal()
    {
        transform.rotation = rotacionInicial;
        transform.position = posicionOriginal;
    }

    private void DesactivarObjetoActivarZona2()
    {
        if (objetoActivarZona2 != null)
        {
            objetoActivarZona2.SetActive(false);
            if (Overlay != null)
            {
                Overlay.SetActive(false);
            }
        }
    }
}
