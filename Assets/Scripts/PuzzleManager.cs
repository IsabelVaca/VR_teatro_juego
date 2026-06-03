using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [Header("Configuración del acertijo")]
    public int totalObjectsNeeded = 3;

    [Header("Progreso")]
    public int objectsPlacedCorrectly = 0;

    [Header("Estados")]
    public bool doorUnlocked = false;
    public bool puzzleCompleted = false;

    [Header("Objetos que aparecen al completar")]
    public GameObject posterPista2;
    public GameObject keyObject;
    public GameObject completedText;
    public GameObject doorUnlockedText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (posterPista2 != null)
            posterPista2.SetActive(false);

        if (keyObject != null)
            keyObject.SetActive(false);

        if (completedText != null)
            completedText.SetActive(false);

        if (doorUnlockedText != null)
            doorUnlockedText.SetActive(false);
    }

    public void RegisterCorrectObject()
    {
        if (puzzleCompleted) return;

        objectsPlacedCorrectly++;

        Debug.Log("Progreso del acertijo: " + objectsPlacedCorrectly + "/" + totalObjectsNeeded);

        if (objectsPlacedCorrectly >= 2 && !doorUnlocked)
        {
            UnlockDoor();
        }

        if (objectsPlacedCorrectly >= totalObjectsNeeded)
        {
            CompletePuzzle();
        }
    }

    private void UnlockDoor()
    {
        doorUnlocked = true;

        Debug.Log("Se colocaron 2 objetos. Puerta desbloqueada.");

        if (doorUnlockedText != null)
            doorUnlockedText.SetActive(true);

        // Aquí después metes la lógica de la puerta.
    }

    private void CompletePuzzle()
    {
        puzzleCompleted = true;

        Debug.Log("Acertijo completado. Los 3 objetos están en su lugar.");

        if (completedText != null)
            completedText.SetActive(true);

        if (posterPista2 != null)
            posterPista2.SetActive(true);

        if (keyObject != null)
            keyObject.SetActive(true);
    }
}