using UnityEngine;
using UnityEngine.UI;

public class MostrarTextoDespuesAnimacion : MonoBehaviour
{
    public Text textoTarea;

    void Start()
    {
        textoTarea.gameObject.SetActive(false);
    }

    void OnAnimationEnd()
    {
        textoTarea.gameObject.SetActive(true);
    }
}
