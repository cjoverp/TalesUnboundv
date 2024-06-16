using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    public string loadingSceneName = "LoadingScene";
    public string initialSceneName = "MenuInicial2";

    private void Start()
    {
        PlayerPrefs.SetString("NextScene", initialSceneName);
        SceneManager.LoadScene(loadingSceneName);
    }
}
