using UnityEngine;
using UnityEngine.UI;

public class ButtonDelayedActivator : MonoBehaviour
{
    public Button targetButton; 
    public float activationDelay = 1f; 

    private void Start()
    {
        if (targetButton != null)
        {
            targetButton.gameObject.SetActive(false);
        }
    }

    public void ActivateButtonWithDelay()
    {
        if (targetButton != null)
        {
            targetButton.gameObject.SetActive(false);
            Invoke("ActivateButton", 2f);
        }
    }

    private void ActivateButton()
    {
        // Activa el botón
        if (targetButton != null)
        {
            targetButton.gameObject.SetActive(true);
        }
    }
}
