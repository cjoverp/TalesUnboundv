using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public CargarEscena cargarEscena;
    [SerializeField] private Button jugarButton;
    [SerializeField] private Button nuevaPartidaButton; 

    private void Start()
    { 
        if((jugarButton != null) && (nuevaPartidaButton != null))
        {
            jugarButton.gameObject.SetActive(false);
            nuevaPartidaButton.gameObject.SetActive(false);
            if (SaveSystem.HasSavedProgress())
            {
                Invoke("ActivateJugarButton", 1f);
                Invoke("ActivateNuevaPartidaButton", 1.5f);
            }
            else
            {
                Invoke("ActivateNuevaPartidaButton", 1f);
            }
        }
    }
    private void ActivateJugarButton()
    {
        jugarButton.gameObject.SetActive(true);
    }

    private void ActivateNuevaPartidaButton()
    {
        nuevaPartidaButton.gameObject.SetActive(true);
    }

    public void Jugar()
    {
        string savedScene = SaveSystem.LoadProgress();
        if (!string.IsNullOrEmpty(savedScene) && IsGameScene(savedScene))
        {
            SaveSystem.SaveProgress(SceneManager.GetActiveScene().name);
            cargarEscena.CargarEscenaConLoading(savedScene);
        }
        else
        {
            cargarEscena.CargaEscenaInicial();
        }
    }
    public void NuevaPartida()
    {
        SaveSystem.ClearProgress();
        cargarEscena.CargarJuego();
    }

    public void PrimerJugar()
    {
        cargarEscena.CargarMenuJuego();
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void SalirMenuJuego()
    {
        cargarEscena.CargaEscenaInicial();
    }

    private bool IsGameScene(string sceneName)
    {
        string[] gameScenes = { "MinijuegoDia", "MinijuegoDia2", "MinijuegoDia3", "MinijuegoNoche",
                                "MinijuegoNochePt2", "FinalPrueba", "TransicionDiaNoche",
                                "NocheLvl2Pt1", "NocheLvl2Pt2", "NocheLvl3", "NocheLvl3Pt2" };

        foreach (string gameScene in gameScenes)
        {
            if (sceneName.Equals(gameScene))
            {
                return true;
            }
        }
        return false;
    }
}
