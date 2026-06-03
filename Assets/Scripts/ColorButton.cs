using UnityEngine;
using UnityEngine.Events;

public class ColorButton : MonoBehaviour
{
    public string colorName;
    public UnityEvent<string> onButtonPressed;

    public void PressButton()
    {
        Debug.Log("Presionaste: " + colorName);
        onButtonPressed.Invoke(colorName);
    }
}