using UnityEngine;

public class ColorPuzzleManager : MonoBehaviour
{
    public string[] correctSequence = { "Azul", "Rojo", "Verde" };

    private int currentIndex = 0;
    private bool puzzleCompleted = false;

    public GameObject objectToActivate;
    public GameObject wrongFeedback;
    public GameObject correctFeedback;

    public void CheckColor(string colorPressed)
    {
        if (puzzleCompleted) return;

        Debug.Log("Color recibido: " + colorPressed);

        if (colorPressed == correctSequence[currentIndex])
        {
            currentIndex++;
            Debug.Log("Correcto. Paso actual: " + currentIndex);

            if (currentIndex >= correctSequence.Length)
            {
                CompletePuzzle();
            }
        }
        else
        {
            Debug.Log("Incorrecto. Reiniciar");
            currentIndex = 0;

            if (wrongFeedback != null)
            {
                wrongFeedback.SetActive(true);
                Invoke(nameof(HideWrongFeedback), 1.5f);
            }
        }
    }

    void CompletePuzzle()
    {
        puzzleCompleted = true;
        Debug.Log("Acertijo 2 completado");

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        if (correctFeedback != null)
        {
            correctFeedback.SetActive(true);
        }
    }

    void HideWrongFeedback()
    {
        if (wrongFeedback != null)
        {
            wrongFeedback.SetActive(false);
        }
    }
}