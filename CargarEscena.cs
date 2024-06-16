using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    public string PantallaInicial = "MenuInicial";
    public string MinijuegoDia = "MinijuegoDia";
    public string MenuJuego = "MenuJuego";
    public string MenuInicial2 = "MenuInicial2";
    public string MinijuegoDia2 = "MinijuegoDia2";
    public string MinijuegoDia3 = "MinijuegoDia3";
    public string MinijuegoNoche = "MinijuegoNoche";
    public string MinijuegoNochePt2 = "MinijuegoNochePt2";
    public string FinalPrueba = "FinalPrueba";
    public string Tutorial = "Tutorial";
    public string Tutorial2 = "Tutorial2";
    public string CinematicaDracula = "CinematicaDracula";
    public string TransicionDiaNoche = "TransicionDiaNoche";
    public string MinijuegoNocheLvl2Pt1 = "NocheLvl2Pt1";
    public string MinijuegoNocheLvl2Pt2 = "NocheLvl2Pt2";
    public string MinijuegoNocheLvL3 = "NocheLvl3";
    public string MinijuegoNocheLvL3Pt2 = "NocheLvl3Pt2";
    public string Juego = "Juego";
    public string Creditos = "Creditos";
    public string LoadingScene = "LoadingScene"; 

    public void CargarEscenaConLoading(string escenaDestino)
    {
        if (escenaDestino != SceneManager.GetActiveScene().name)
        {
            PlayerPrefs.SetString("NextScene", escenaDestino);
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            SaveSystem.SaveProgress(escenaDestino);
            SceneManager.LoadScene(LoadingScene);
        }
        else
        {
            Debug.Log("Se ha intentado cargar la escena en la que ya se está.");
        }
    }

    public void CargarEscenaDirecta(string escenaDestino)
    {
        if (escenaDestino != SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene(escenaDestino);
        }
        else
        {
            Debug.Log("Se ha intentado cargar la escena en la que ya se está.");
        }
    }
    // Métodos para cargar escenas utilizando la escena de cargado
    public void CargarNuevaEscena() => CargarEscenaConLoading(MinijuegoNoche);
    public void CargarMenuJuego() => CargarEscenaConLoading(MenuJuego);
    public void CargarEscenaTutorial() => CargarEscenaConLoading(Tutorial);
    public void CargaEscenaInicial() => CargarEscenaConLoading(MenuInicial2);
    public void CargarMinijuegoDia() => CargarEscenaConLoading(MinijuegoDia);
    public void CargarPantallaInicial() => CargarEscenaConLoading(PantallaInicial);
    public void CargarEscenaNoche() => CargarEscenaConLoading(MinijuegoNochePt2);
    public void CargarMinijuegoDia2() => CargarEscenaConLoading(MinijuegoDia2);
    public void CargarMinijuegoDia3() => CargarEscenaConLoading(MinijuegoDia3);
    public void CargarEscenaFinalPrueba() => CargarEscenaConLoading(FinalPrueba);
    public void CargarTransicionDiaNoche() => CargarEscenaConLoading(TransicionDiaNoche);
    public void CargarJuego() => CargarEscenaConLoading(Juego);
    public void CargarMinijuegoNocheLvl2Pt1() => CargarEscenaConLoading(MinijuegoNocheLvl2Pt1);
    public void CargarMinijuegoNocheLvl2Pt2() => CargarEscenaConLoading(MinijuegoNocheLvl2Pt2);
    public void CargarMinijuegoNocheLvl3() => CargarEscenaConLoading(MinijuegoNocheLvL3);
    public void CargarMinijuegoNocheLvl3Pt2() => CargarEscenaConLoading(MinijuegoNocheLvL3Pt2);

    // Métodos para cargar escenas con delay
    public void CargarEscenaDelay() => Invoke("CargarNuevaEscena", 2f);
    public void CargarEscenaDelay2() => Invoke("CargarMinijuegoDia2", 2f);
    public void CargarEscenaFinalPruebaDelay() => Invoke("CargarEscenaFinalPrueba", 2f);
    public void CargarTransicionDiaNocheDelay() => Invoke("CargarTransicionDiaNoche", 2f);
    public void CargarNivelNocheLvl2() => Invoke("CargarMinijuegoNocheLvl2Pt1", 2f);
    public void CargarNivelNocheLvl3Delay() => Invoke("CargarMinijuegoNocheLvl3", 2f);
    public void CargarMinijuegoDia2Delay() => Invoke("CargarMinijuegoDia2", 2f);
    public void CargarMinijuegoDia3Delay() => Invoke("CargarMinijuegoDia3", 2f);

    // Métodos para cargar escenas directamente
    public void CargarMenuInicial2() => CargarEscenaDirecta(MenuInicial2);
    public void CargarCreditos() => CargarEscenaDirecta(Creditos);
    public void CargarCinematicaDracula() => CargarEscenaDirecta(CinematicaDracula);
    public void CargarPrimeraEscenaNoche() => CargarEscenaDirecta(MinijuegoNoche);
    public void CargarEscenaTutorial2() => CargarEscenaDirecta(Tutorial2);
}
