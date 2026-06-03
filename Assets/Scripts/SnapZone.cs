using UnityEngine;

public class SnapZone : MonoBehaviour
{
    public string correctTag;
    public Transform snapPoint;
    public bool lockObject = true;

    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed) return;

        GameObject obj = other.gameObject;

        // Revisa si el objeto que entró tiene el tag correcto
        if (!obj.CompareTag(correctTag))
        {
            // Si el collider está en un hijo, revisa también el padre
            if (other.transform.parent != null && other.transform.parent.CompareTag(correctTag))
            {
                obj = other.transform.parent.gameObject;
            }
            else
            {
                Debug.Log("Objeto incorrecto en " + gameObject.name + ": " + other.name);
                return;
            }
        }

        // Mueve el objeto al punto exacto
        if (snapPoint != null)
        {
            obj.transform.position = snapPoint.position;
            obj.transform.rotation = snapPoint.rotation;
        }

        Rigidbody rb = obj.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (lockObject)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }

        completed = true;

        Debug.Log(obj.name + " colocado correctamente en " + gameObject.name);

        if (PuzzleManager.Instance != null)
        {
            PuzzleManager.Instance.RegisterCorrectObject();
        }
    }
}