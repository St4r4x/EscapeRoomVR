using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public InputActionReference touche;
    public GameObject Projectile;

    private void OnEnable()
    {
        if (touche == null || touche.action == null) return;
        touche.action.Enable();
        touche.action.performed += OnTouchePressed;
    }

    private void OnDisable()
    {
        if (touche == null || touche.action == null) return;
        touche.action.performed -= OnTouchePressed;
        touche.action.Disable();
    }

    private void OnTouchePressed(InputAction.CallbackContext obj)
    {
        Instantiate(Projectile, transform.position, transform.rotation);
    }
}
