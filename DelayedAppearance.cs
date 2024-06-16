using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    public float tiempoEspera = 3.0f;
    public static void ActivarObjeto(GameObject objeto)
    {
        objeto.SetActive(true);

    }
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("ActivarEsteObjeto", tiempoEspera);
    }

    void ActivarEsteObjeto()
    {
        ActivarObjeto(gameObject);
    }
}
