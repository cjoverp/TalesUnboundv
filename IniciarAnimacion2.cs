using UnityEngine;

public class IniciarAnimacionOnClick2 : MonoBehaviour
{
    public Animator animatorObjeto2;
    public Animator animatorCamara2;
    public GameObject otroGameObject3; 
    public GameObject otroGameObject4;
    public GameObject otroGameObject5;

    public void OnClick2()
    {
        if (animatorObjeto2 != null)
        {
            animatorObjeto2.SetTrigger("IniciarAnimacion2");
            animatorCamara2.SetTrigger("IniciarAnimacionSeg");
            Invoke("ActivarGameObject2", 2f);
        }
        else
        {
            Debug.LogWarning("Animator no se ha asignado");
        }
    }

    private void ActivarGameObject2()
    {
        otroGameObject3.SetActive(true);
        otroGameObject4.SetActive(true);
        otroGameObject5.SetActive(true);
    }
}
