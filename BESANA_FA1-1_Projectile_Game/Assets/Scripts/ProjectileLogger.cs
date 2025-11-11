using UnityEngine;

public class ProjectileLogger : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float lifetime = 5f; // Seconds before projectile disappears

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;

        // Automatically destroy projectile after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);
        Debug.Log("Projectile traveled: " + distanceTraveled.ToString("F2"));

        // Destroy immediately on collision
        Destroy(gameObject);
    }
}
