using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public bool circularMotion = true;

    [Header("Scaling (Pulsate) Settings")]
    public float pulseSpeed = 2f;
    public float scaleAmplitude = 0.3f;

    [Header("Target Settings")]
    public Transform player; // Automatically assigned

    private Vector3 startPos;
    private Vector3 baseScale;

    void Start()
    {
        startPos = transform.position;
        baseScale = transform.localScale;

        // Auto-assign player
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("EnemyBehavior: No GameObject with tag 'Player' found!");
            }
        }
    }

    void Update()
    {
        MoveEnemy();
        PulsateEnemy();
        FacePlayer();
    }

    void MoveEnemy()
    {
        if (circularMotion)
        {
            float x = Mathf.Sin(Time.time * moveSpeed) * moveRange;
            float z = Mathf.Cos(Time.time * moveSpeed) * moveRange;
            transform.position = startPos + new Vector3(x, 0f, z);
        }
        else
        {
            float x = Mathf.Sin(Time.time * moveSpeed) * moveRange;
            transform.position = startPos + new Vector3(x, 0f, 0f);
        }
    }

    void PulsateEnemy()
    {
        float scaleFactor = 1f + Mathf.Sin(Time.time * pulseSpeed) * scaleAmplitude;
        transform.localScale = baseScale * scaleFactor;
    }

    void FacePlayer()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // horizontal rotation only
        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Assumes your projectile has tag "Projectile"
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject); // destroy projectile
            Destroy(gameObject);       // destroy this enemy
        }
    }
}
