using UnityEngine;
using UnityEngine.Events;

public class ColorButton : MonoBehaviour
{
    [Header("Color del botón")]
    public string colorName;

    [Header("Evento al activar botón")]
    public UnityEvent<string> onButtonPressed;

    [Header("Materiales")]
    public Renderer buttonRenderer;
    public Material normalMaterial;
    public Material hoverMaterial;

    [Header("Evitar que se active muchas veces")]
    public float cooldown = 1f;
    private bool canPress = true;

    public void OnHoverEnter()
    {
        if (buttonRenderer != null && hoverMaterial != null)
        {
            buttonRenderer.material = hoverMaterial;
        }

        PressButton();
    }

    public void OnHoverExit()
    {
        if (buttonRenderer != null && normalMaterial != null)
        {
            buttonRenderer.material = normalMaterial;
        }
    }

    public void PressButton()
    {
        if (!canPress) return;

        canPress = false;

        Debug.Log("Presionaste: " + colorName);
        onButtonPressed.Invoke(colorName);

        Invoke(nameof(ResetButton), cooldown);
    }

    private void ResetButton()
    {
        canPress = true;
    }
}