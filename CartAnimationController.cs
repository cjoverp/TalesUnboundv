using UnityEngine;

public class CartAnimationController : MonoBehaviour
{
    public Animator cartAnimator;
    public string animationCompletedParam = "AnimationCompleted";

    private void Start()
    {
        if (cartAnimator == null)
        {
            Debug.LogError("Animator del carrito no está asignado.");
        }
    }


    public void StartCartAnimation()
    {
        cartAnimator.enabled = true;
    }

    public void OnCartAnimationComplete()
    {
        cartAnimator.SetBool(animationCompletedParam, true);
    }
}


