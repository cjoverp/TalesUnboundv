using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public float initialDelay = 4.03f;
    public float countdownTime = 6f; 
    private bool isDelayFinished = false;
    private bool countdownStarted = false; 

    void Start()
    {
        Invoke("FinishDelay", initialDelay);
    }

    void FinishDelay()
    {
        isDelayFinished = true;
    }

    void Update()
    {
        if (!isDelayFinished)
            return;

        if (!countdownStarted)
        {
            countdownStarted = true;
            countdownText.text = Mathf.CeilToInt(countdownTime - 1).ToString();
        }


        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(countdownTime, 0f);

        if (countdownTime <= 0f)
        {
            enabled = false;
            countdownText.text = ""; 
            return;
        }

        if (Mathf.CeilToInt(countdownTime) == 1)
        {
            countdownText.text = "0";
        }
        else
        {
            countdownText.text = Mathf.CeilToInt(countdownTime - 1).ToString();
        }
    }
}
