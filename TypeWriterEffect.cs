using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypewriterEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f; // Velocidad de escritura en segundos por letra
    private TMP_Text tmpText; // El componente TextMeshPro
    private string fullText; // El texto completo
    private Coroutine typingCoroutine; // Para rastrear la corrutina
    private int currentCharacterIndex = 0; // Para rastrear el índice del carácter actual
    private bool isPaused = false; // Para rastrear el estado de pausa
    private bool isWritingPaused = false; // Para rastrear si la escritura está pausada por los botones específicos

    public Button pauseButton; // Botón para pausar la escritura
    public Button resumeButton; // Botón para reanudar la escritura
    public Button pauseWritingButton; // Botón para pausar específicamente la escritura
    public Button resumeWritingButton; // Botón para reanudar específicamente la escritura

    public CargarEscena cargarEscena; // Referencia al script CargarEscena

    void Start()
    {
        tmpText = GetComponent<TMP_Text>(); // Obtener el componente TextMeshPro
        if (tmpText == null)
        {
            return;
        }

        fullText = tmpText.text; // Guardar el texto completo
        if (string.IsNullOrEmpty(fullText))
        {
            Debug.LogWarning("El texto completo está vacío.");
        }

        tmpText.text = ""; // Vaciar el texto inicial
        typingCoroutine = StartCoroutine(TypeText()); // Iniciar la corrutina de escritura

        // Asignar métodos a los eventos de los botones si están asignados
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseTyping);
        }

        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeTyping);
        }

        if (pauseWritingButton != null)
        {
            pauseWritingButton.onClick.AddListener(PauseWriting);
        }

        if (resumeWritingButton != null)
        {
            resumeWritingButton.onClick.AddListener(ResumeWriting);
        }
    }

    IEnumerator TypeText()
    {
        Debug.Log("Iniciando corrutina de escritura.");
        while (currentCharacterIndex < fullText.Length)
        {
            if (!isPaused && !isWritingPaused)
            {
                tmpText.text += fullText[currentCharacterIndex]; // Añadir una letra al texto mostrado
                currentCharacterIndex++; // Incrementar el índice del carácter actual
                yield return new WaitForSeconds(typingSpeed); // Esperar antes de añadir la siguiente letra
            }
            else
            {
                yield return null; // Esperar hasta que se reanude
            }
        }

        // Si la escena actual es "FinalPrueba", llamar a CargarCreditos() después de 2 segundos
        if (SceneManager.GetActiveScene().name == "FinalPrueba")
        {
            yield return new WaitForSeconds(2f);
            if (cargarEscena != null)
            {
                cargarEscena.CargarCreditos();
            }
        }
    }

    public void PauseTyping()
    {
        if (!isPaused)
        {
            isPaused = true;
        }
    }

    public void ResumeTyping()
    {
        if (isPaused)
        {
            isPaused = false;
            if (typingCoroutine == null)
            {
                typingCoroutine = StartCoroutine(TypeText());
            }
        }
    }

    public void PauseWriting()
    {
        if (!isWritingPaused)
        {
            isWritingPaused = true;
        }
    }

    public void ResumeWriting()
    {
        if (isWritingPaused)
        {
            isWritingPaused = false;
            if (typingCoroutine == null)
            {
                typingCoroutine = StartCoroutine(TypeText());
            }
        }
    }
}
