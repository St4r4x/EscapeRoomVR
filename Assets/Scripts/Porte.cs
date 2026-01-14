using UnityEngine;

public class Porte : MonoBehaviour
{
    public bool isOpen;

    public Transform Pivot;
    public Transform OpenedReference;
    public Transform ClosedReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            Pivot.rotation = Quaternion.Slerp(Pivot.rotation, OpenedReference.rotation, Time.deltaTime * 2);
        }
        else
        {
            Pivot.rotation = Quaternion.Slerp(Pivot.rotation, ClosedReference.rotation, Time.deltaTime * 2);
        }
        
    }
}
