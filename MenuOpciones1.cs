using UnityEngine;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private Animator[] animators;

    public void ActivarMenuOpciones()
    {
        menuOpciones.SetActive(true);
        ReiniciarAnimaciones();
    }

    public void DesactivarMenuOpciones()
    {
        menuOpciones.SetActive(false);
    }

    private void ReiniciarAnimaciones()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.Rebind();
                animator.Update(0f);
            }
        }
    }
}
