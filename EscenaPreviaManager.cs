using UnityEngine;

public static class EscenaPreviaManager
{
    public static string nombreEscenaPrevia;

    public static void GuardarNombreEscenaPrevia(string nombreEscena)
    {
        nombreEscenaPrevia = nombreEscena;
    }

    public static string ObtenerNombreEscenaPrevia()
    {
        return nombreEscenaPrevia;
    }
}
