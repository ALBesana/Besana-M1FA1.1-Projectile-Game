using UnityEngine;

public class ProjectileLogger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        float distanceTraveled = Vector3.Distance(initialPosition, transform.position);
        Debug.Log("Projectile traveled: " + distanceTraveled.ToString("F2"));
    }
}
