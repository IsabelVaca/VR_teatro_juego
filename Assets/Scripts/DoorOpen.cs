using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Vector3 openRotation = new Vector3(0, 90, 0);
    public float openSpeed = 2f;

    private bool shouldOpen = false;
    private Quaternion closedRotation;
    private Quaternion targetRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles + openRotation);
    }

    void Update()
    {
        if (shouldOpen)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );
        }
    }

    public void OpenDoor()
    {
        shouldOpen = true;
        Debug.Log("Puerta abierta");
    }
}