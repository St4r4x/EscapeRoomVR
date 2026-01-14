using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [Tooltip("UnityEvent invoked when the trigger is entered")] public UnityEvent onEnter;
    [Tooltip("UnityEvent invoked when the trigger is exited")] public UnityEvent onExit;

    [Tooltip("Reference to the Porte (door) script to control (optional)")] public Porte door;
    [Tooltip("Name of the GameObject that should trigger the door")] public string triggerName = "Complete XR Origin Set Up Hands Variant";
    [Tooltip("If true, door closes on Exit when matching the trigger")] public bool closeOnExit = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by " + other.name);
        // invoke UnityEvent listeners
        onEnter?.Invoke();

        // convenience: if a Porte is assigned, call its Open method
        if (door != null)
        {
            if (!string.IsNullOrEmpty(triggerName) && other.name.Contains(triggerName))
            {
                door.OpenDoor();
                Debug.Log("Opening door via TriggerArea (door.OpenDoor())");
            }
            else if (other.CompareTag("Player"))
            {
                door.OpenDoor();
                Debug.Log("Opening door (player tag) via TriggerArea (door.OpenDoor())");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited by " + other.name);
        // invoke UnityEvent listeners
        onExit?.Invoke();

        // convenience: if a Porte is assigned, call its Close method
        if (door != null && closeOnExit)
        {
            if (!string.IsNullOrEmpty(triggerName) && other.name.Contains(triggerName))
            {
                door.CloseDoor();
                Debug.Log("Closing door via TriggerArea (door.CloseDoor())");
            }
            else if (other.CompareTag("Player"))
            {
                door.CloseDoor();
                Debug.Log("Closing door (player tag) via TriggerArea (door.CloseDoor())");
            }
        }
    }
}
