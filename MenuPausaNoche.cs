using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaNoche : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private List<GameObject> objectsToActivateOnStart;
    [SerializeField] private List<GameObject> objectsToTrack;
    [SerializeField] private List<Animator> animatorsToControl;
    public CargarEscena cargarEscena;
    public AudioManager audioManager;

    private Dictionary<GameObject, bool> objectStatesBeforePause = new Dictionary<GameObject, bool>();

    private void Awake()
    {
        if (objectsToTrack == null || objectsToTrack.Count == 0)
        {
        }
        else
        {
            foreach (var obj in objectsToTrack)
            {
                if (obj == null)
                {
                    Debug.LogError("No se ha asignado alguno de los objetos a seguir");
                }
            }
        }

        foreach (GameObject obj in objectsToActivateOnStart)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        if (animatorsToControl != null)
        {
            foreach (var animator in animatorsToControl)
            {
                if (animator != null)
                {
                    animator.updateMode = AnimatorUpdateMode.UnscaledTime;
                }
                else
                {
                    Debug.LogError("No se ha asignado alguno de los objetos a seguir");
                }
            }
        }
        Time.timeScale = 1f;
        LibroController.isPaused = false;
        menuPausa.SetActive(false); 
        botonPausa.SetActive(true);
    }

    public void Pausa()
    {
        objectStatesBeforePause.Clear();
        foreach (GameObject obj in objectsToTrack)
        {
            if (obj != null)
            {
                bool isActive = obj.activeInHierarchy;
                objectStatesBeforePause[obj] = isActive;
                obj.SetActive(false);
            }
        }
        LibroController.isPaused = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

        if (audioManager != null)
        {
            audioManager.PauseAllAudio();
        }
        if (animatorsToControl != null)
        {
            foreach (var animator in animatorsToControl)
            {
                if (animator != null)
                {
                    animator.updateMode = AnimatorUpdateMode.UnscaledTime; 
                    animator.SetTrigger("OpenMenu");
                }
            }
        }
    }

    public void Reanudar()
    {

        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        foreach (var entry in objectStatesBeforePause)
        {
            if (entry.Key != null)
            {
                entry.Key.SetActive(entry.Value);
            }
        }
        LibroController.isPaused = false;

        if (audioManager != null)
        {
            audioManager.ResumeAllAudio();
        }

        if (animatorsToControl != null)
        {
            foreach (var animator in animatorsToControl)
            {
                if (animator != null)
                {
                    animator.updateMode = AnimatorUpdateMode.Normal;
                }
            }
        }
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Volver()
    {

        Time.timeScale = 1f;
        cargarEscena.CargarMenuInicial2();
        if (animatorsToControl != null)
        {
            foreach (var animator in animatorsToControl)
            {
                if (animator != null)
                {
                    animator.Play("AnimMusica3", 0, 0f);
                }
            }
        }
    }
}
