using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingManager : MonoBehaviour
{
    public TMP_Text loadingText; 
    public Slider progressBar;
    public Image lockImage; 
    public Image lockFillImage;
    public Sprite lockOpenSprite;
    public Sprite lockClosedSprite;
    private string baseLoadingText = "Cargando";

    private void Start()
    {
        if (lockImage != null && lockClosedSprite != null)
        {
            lockImage.sprite = lockClosedSprite;
        }

        StartCoroutine(LoadAsyncOperation());
        StartCoroutine(UpdateLoadingText());
        StartCoroutine(AnimateLockFill());
    }

    private IEnumerator LoadAsyncOperation()
    {
        string sceneToLoad = PlayerPrefs.GetString("NextScene", "MenuInicial2");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress;
            }
            if (asyncLoad.progress >= 0.9f)
            {
                if (lockImage != null && lockOpenSprite != null)
                {
                    lockImage.sprite = lockOpenSprite;
                }
                while (lockImage.sprite != lockOpenSprite)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(1f);
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private IEnumerator UpdateLoadingText()
    {
        int dotCount = 0;
        while (true)
        {
            string dots = new string('.', dotCount % 4);
            if (loadingText != null)
            {
                loadingText.text = baseLoadingText + dots;
            }
            dotCount++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator AnimateLockFill()
    {
        float fillDuration = 5.0f;
        float elapsedTime = 0f;

        while (elapsedTime < fillDuration)
        {
            elapsedTime += Time.deltaTime;
            float fillAmount = Mathf.Clamp01(elapsedTime / fillDuration);
            if (lockFillImage != null)
            {
                lockFillImage.fillAmount = fillAmount;
            }
            yield return null;
        }
        if (lockFillImage != null)
        {
            lockFillImage.fillAmount = 1f;
        }
    }
}
