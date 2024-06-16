using UnityEngine;

public class IniciarAnimacionOnClick : MonoBehaviour
{
    public Animator animatorObjeto; 
    public Animator animatorCamara;
    public GameObject otroGameObject;
    public GameObject otroGameObject2;
    public GameObject flecha;
    public GameObject ImagenBotonTareas;

    public void OnClick()
    {
        if (animatorObjeto != null)
        {
            animatorObjeto.SetTrigger("IniciarAnimacion");
      
            if (otroGameObject != null)
            {
                Invoke("ActivarGameObject", 2f); 
            }
            if (flecha != null)
            {
                Invoke("ActivarFlecha", 2f); 
            }
        }
        else
        {
            Debug.LogWarning("Animator no asignado");
        }

        if(animatorCamara != null)
        {
            animatorCamara.SetTrigger("IniciarAnimacion1");
            if (otroGameObject != null)
            {
                Invoke("ActivarGameObject", 2f);
            }
        }
    }
    private void ActivarGameObject()
    {
        otroGameObject.SetActive(true);
        otroGameObject2.SetActive(true);
    }

    private void ActivarFlecha()
    {

        flecha.SetActive(true);
        if(ImagenBotonTareas != null)
        {
            ImagenBotonTareas.SetActive(true);
        }
    }
}


