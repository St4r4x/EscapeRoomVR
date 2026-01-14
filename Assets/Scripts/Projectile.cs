using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("Optional reference to a Rigidbody; if empty the script will GetComponent<Rigidbody>()")]
    public Rigidbody rb;
    public float initialForce;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Projectile: no Rigidbody found on " + gameObject.name + ". Add a Rigidbody or assign it in the inspector.");
            return;
        }

        Vector3 forward = transform.forward;
        if (float.IsNaN(forward.x) || float.IsNaN(forward.y) || float.IsNaN(forward.z) || float.IsInfinity(forward.x) || float.IsInfinity(forward.y) || float.IsInfinity(forward.z))
        {
            forward = Vector3.forward;
        }

        if (initialForce != 0f)
            rb.AddForce(forward.normalized * initialForce, ForceMode.Impulse);
    }
}
