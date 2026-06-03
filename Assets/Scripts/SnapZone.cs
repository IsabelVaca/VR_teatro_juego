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

        if (other.CompareTag(correctTag))
        {
            GameObject obj = other.gameObject;

            obj.transform.position = snapPoint.position;
            obj.transform.rotation = snapPoint.rotation;

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

            Debug.Log(obj.name + " colocado correctamente.");
            
            PuzzleManager.Instance.RegisterCorrectObject();
        }

    }
}