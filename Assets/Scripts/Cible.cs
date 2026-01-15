using System.Runtime.InteropServices;
using UnityEngine;

public class Script : MonoBehaviour
{
    public int vie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Cible touchée");
            Damage(1);
        }
    }
    private void Damage(int damage)
    {
        vie -= damage;
        if (vie <= 0)
        {
            Destroy(gameObject);
        }
    }
}
