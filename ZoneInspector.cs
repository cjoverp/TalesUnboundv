using UnityEngine;

public class ZoneSelector : MonoBehaviour
{
    public Vector2 zonaMinima;
    public Vector2 zonaMaxima;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 minima = new Vector3(zonaMinima.x, zonaMinima.y, 0);
        Vector3 maxima = new Vector3(zonaMaxima.x, zonaMaxima.y, 0);
        Gizmos.DrawLine(new Vector3(minima.x, minima.y, 0), new Vector3(maxima.x, minima.y, 0));
        Gizmos.DrawLine(new Vector3(maxima.x, minima.y, 0), new Vector3(maxima.x, maxima.y, 0));
        Gizmos.DrawLine(new Vector3(maxima.x, maxima.y, 0), new Vector3(minima.x, maxima.y, 0));
        Gizmos.DrawLine(new Vector3(minima.x, maxima.y, 0), new Vector3(minima.x, minima.y, 0));
    }
}
