using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Tooltip("Reference to the Porte (door) script to control")] public Porte door;
    [Tooltip("Name of the GameObject that should trigger the door")] public string triggerName = "Complete XR Origin Set Up Hands Variant";
    [Tooltip("If true, door opens on Enter and closes on Exit")] public bool closeOnExit = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by " + other.name);
        if (door == null) return;
        if (!string.IsNullOrEmpty(triggerName) && other.name.Contains(triggerName))
        {
            door.isOpen = true;
            Debug.Log("Opening door via TriggerArea");
        }
        else if (other.CompareTag("Player"))
        {
            // fallback: open for objects tagged Player
            door.isOpen = true;
            Debug.Log("Opening door (player tag) via TriggerArea");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited by " + other.name);
        if (door == null) return;
        if (closeOnExit && (!string.IsNullOrEmpty(triggerName) && other.name.Contains(triggerName)))
        {
            door.isOpen = false;
            Debug.Log("Closing door via TriggerArea");
        }
        else if (closeOnExit && other.CompareTag("Player"))
        {
            door.isOpen = false;
            Debug.Log("Closing door (player tag) via TriggerArea");
        }
    }
}
