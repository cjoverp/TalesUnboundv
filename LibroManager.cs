using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibroManager : MonoBehaviour
{
    public GameObject[] libros;
    public GameObject librosOrdenados; 
    public CargarEscena cargarEscena;

    private int librosColocados;

    private void Start()
    {
        librosColocados = 0;
        foreach (var libro in libros)
        {
            var libroController = libro.GetComponent<LibroController>();
            if (libroController != null)
            {
                libroController.LibrosColocadosActualizados += OnLibrosColocadosActualizados;
            }
        }
    }

    private void OnLibrosColocadosActualizados(int totalColocados)
    {
        librosColocados = totalColocados;
        if (librosColocados >= libros.Length)
        {
            DesactivarLibrosYActivarOrdenados();
        }
    }

    public void DesactivarLibrosYActivarOrdenados()
    {
        StartCoroutine(DesactivarLibrosYActivarOrdenadosCoroutine());
    }

    private IEnumerator DesactivarLibrosYActivarOrdenadosCoroutine()
    {
        for (int i = 0; i < libros.Length; i++)
        {
            libros[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
        librosOrdenados.SetActive(true);
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "MinijuegoDia3":
                cargarEscena.CargarTransicionDiaNocheDelay();
                break;
            case "MinijuegoDia":
                cargarEscena.CargarMinijuegoDia2Delay();
                break;
            case "MinijuegoDia2":
                cargarEscena.CargarMinijuegoDia3Delay();
                break;
            default:
                Debug.LogWarning("La escena no se reconoce");
                break;
        }
    }
}
