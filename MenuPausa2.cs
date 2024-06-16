using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa2 : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject darkOverlay;
    [SerializeField] private List<LibroController> libros;
    private Animator menuAnimator; 

    private void Start()
    {

        menuAnimator = menuPausa.GetComponent<Animator>();
        menuPausa.SetActive(false);
        darkOverlay.SetActive(false);
    }

    public void Pausa2()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        darkOverlay.SetActive(true);
        if (menuAnimator != null)
        {
            menuAnimator.SetTrigger("Open");
        }
        StartCoroutine(DeactivateBooksAfterDelay(0.1f));
    }

    private IEnumerator DeactivateBooksAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        foreach (var libro in libros)
        {
            libro.enabled = false;
        }
    }

    public void Reanudar2()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        darkOverlay.SetActive(false);
        foreach (var libro in libros)
        {
            libro.enabled = true;
        }
    }

    public void Reiniciar2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Volver2()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene("MenuInicial");
        }
    }
}