using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    public Button pauseButton;
    public GameObject botonsinmute; 
    public GameObject botonsinmute2;
    public Animator botonsinmuteAnimator;
    public string triggerName = "Activate"; 

    public float pauseButtonActivationDelay;
    public float botonsinmuteActivationDelay; 

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MinijuegoDia")
        {
            pauseButton.gameObject.SetActive(false);
            botonsinmute.SetActive(false);
        Invoke("ActivatePauseButton", pauseButtonActivationDelay);

        }
    }

    private void ActivatePauseButton()
    {
        pauseButton.gameObject.SetActive(true);
    }

    public void ActivateBotonsinmuteWithDelay()
    {
        Invoke("ActivateBotonsinmute", 11f);
    }

    private void ActivateBotonsinmute()
    {

        botonsinmute2.SetActive(true);
    }

    public void ActivateBotoninmute2()
    {
        // Activa el trigger del Animator
        if (botonsinmuteAnimator != null)
        {
            botonsinmute.SetActive(true);
            botonsinmuteAnimator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el animator del objeto ");
        }
    }
}
