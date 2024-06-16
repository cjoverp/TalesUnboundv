using UnityEngine;

public class MostrarZona : MonoBehaviour
{
    public GameObject objetoZona; 
    public Zona zona1;
    public Zona zona2;

    public static MostrarZona instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnDrawGizmosSelected()
    {
        if (objetoZona != null)
        {
            Vector3 objetoPos = objetoZona.transform.position;
            DibujarZona(zona1, objetoPos, Color.green);
            DibujarZona(zona2, objetoPos, Color.blue);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el objeto");
        }
    }

    public void DibujarZona(Zona zona, Vector3 objetoPos, Color color)
    {
        Vector3 esquinaMinima = objetoPos + new Vector3(zona.minima.x, zona.minima.y, 0f);
        Vector3 esquinaMaxima = objetoPos + new Vector3(zona.maxima.x, zona.minima.y, 0f);
        Vector3 esquinaMaximaY = objetoPos + new Vector3(zona.maxima.x, zona.maxima.y, 0f);
        Vector3 esquinaMinimaY = objetoPos + new Vector3(zona.minima.x, zona.maxima.y, 0f);

        Gizmos.color = color;
        Gizmos.DrawLine(esquinaMinima, esquinaMaxima);
        Gizmos.DrawLine(esquinaMaxima, esquinaMaximaY);
        Gizmos.DrawLine(esquinaMaximaY, esquinaMinimaY);
        Gizmos.DrawLine(esquinaMinimaY, esquinaMinima);
    }

    public static bool EstaEnZona(Vector3 posicion, Zona zona)
    {
        if (instance != null && instance.objetoZona != null)
        {
            Vector3 objetoPos = instance.objetoZona.transform.position;
            Vector3 esquinaMinima = objetoPos + new Vector3(zona.minima.x, zona.minima.y, 0f);
            Vector3 esquinaMaximaY = objetoPos + new Vector3(zona.maxima.x, zona.maxima.y, 0f);

            return posicion.x >= esquinaMinima.x && posicion.x <= esquinaMaximaY.x &&
                   posicion.y >= esquinaMinima.y && posicion.y <= esquinaMaximaY.y;
        }
        return false;
    }
}