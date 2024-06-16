using UnityEngine;

public class ClickableAfterAnimation : MonoBehaviour
{
    public Collider clickableCollider; 

    public void OnAnimationEnd()
    {
        clickableCollider.enabled = true; 

    }
}
