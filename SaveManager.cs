using UnityEngine;

public static class SaveSystem
{
    private const string ProgressKey = "CurrentProgress";
    private static string[] gameScenes = { "MinijuegoDia", "MinijuegoDia2", "MinijuegoDia3", "MinijuegoNoche",
                                           "MinijuegoNochePt2", "FinalPrueba", "TransicionDiaNoche",
                                           "NocheLvl2Pt1", "NocheLvl2Pt2", "NocheLvl3", "NocheLvl3Pt2" };

    public static void SaveProgress(string sceneName)
    {
        if (IsGameScene(sceneName))
        {
            PlayerPrefs.SetString(ProgressKey, sceneName);
            PlayerPrefs.Save();
        }
    }

    public static string LoadProgress()
    {
        return PlayerPrefs.GetString(ProgressKey, string.Empty);
    }

    public static void ClearProgress()
    {
        PlayerPrefs.DeleteKey(ProgressKey);
        PlayerPrefs.Save();
    }

    public static bool HasSavedProgress()
    {
        return PlayerPrefs.HasKey(ProgressKey);
    }

    private static bool IsGameScene(string sceneName)
    {
        foreach (string gameScene in gameScenes)
        {
            if (sceneName.Equals(gameScene))
            {
                return true;
            }
        }
        return false;
    }
}
