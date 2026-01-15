using System.Runtime.InteropServices;
using UnityEngine;

public class Cible : MonoBehaviour
{
    public int vie;
    [Header("Tremblement")]
    public float shakeIntensity = 0.1f; // intensité du tremblement
    public float shakeFrequency = 20f;  // fréquence du tremblement
    public float shakeDuration = 0.5f;  // durée du tremblement en secondes

    private float shakeTimer = 0f;
    private Vector3 initialLocalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialLocalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            float t = Mathf.Clamp01(shakeTimer / shakeDuration); // ratio restants

            float nx = (Mathf.PerlinNoise(Time.time * shakeFrequency, 0f) - 0.5f) * 2f;
            float ny = (Mathf.PerlinNoise(0f, Time.time * shakeFrequency) - 0.5f) * 2f;
            float nz = (Mathf.PerlinNoise(Time.time * shakeFrequency, Time.time * shakeFrequency) - 0.5f) * 2f;

            Vector3 offset = new Vector3(nx, ny, nz) * shakeIntensity * t;
            transform.localPosition = initialLocalPosition + offset;

            if (shakeTimer <= 0f)
                transform.localPosition = initialLocalPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Cible touchée");
            Damage(1);
            // lancer le tremblement
            shakeTimer = shakeDuration;
            Destroy(collision.gameObject);
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
