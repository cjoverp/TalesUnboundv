using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPausa : MonoBehaviour
{
    public Animator animador;
    public GameObject menu;

    public Button reanudarButton;
    public Button reiniciarButton;
    public Button opcionesButton;
    public Button salirButton;

    void Start()
    {
        DesactivarBotones();
    }

    private void DesactivarBotones()
    {
        Debug.Log("Desactivando botones...");
        reanudarButton.interactable = false;
        reiniciarButton.interactable = false;
        opcionesButton.interactable = false;
        salirButton.interactable = false;
    }

    private void ActivarBotones()
    {
        Debug.Log("Activando botones...");
        reanudarButton.interactable = true;
        reiniciarButton.interactable = true;
        opcionesButton.interactable = true;
        salirButton.interactable = true;
    }

    private void Update()
    {

        if (animador != null && animador.isActiveAndEnabled)
        {

            if (!animador.GetCurrentAnimatorStateInfo(0).IsName("Animacion Pausa (Animation Clip)") &&
                animador.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                if (menu != null)
                {
                    ActivarBotones();
                }
                else
                {
                    Debug.LogWarning("No se ha asignado el objeto del menú");
                }
            }
            else
            {

                Debug.Log("La animación se está ejecutando");
            }
        }
    }
}