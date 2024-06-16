using UnityEngine;

public class StartAnimationAndCountdown : MonoBehaviour
{
    public Animator booksAnimator; 
    public CountdownTimer countdownTimer; 
    public float delay = 4.03f; 

    void Start()
    {

        Invoke("StartBooksAnimation", delay);
    }

    void StartBooksAnimation()
    {
        booksAnimator.enabled = true; 
        countdownTimer.enabled = true; 
    }
}

