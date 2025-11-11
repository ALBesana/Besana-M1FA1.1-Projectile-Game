using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;      // Assign your enemy prefab here
    public float spawnRadius = 10f;     // Distance from spawner
    public float spawnHeight = 0.5f;    // Height above ground

    [Header("Spawn Timing")]
    public float spawnInterval = 2f;    // Time between spawns

    private float timer = 0f;

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Spawn enemy when timer exceeds interval
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Random position within a circle around the spawner
        Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(randomPos.x, spawnHeight, randomPos.y) + transform.position;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        // Randomize enemy behavior for variety
        EnemyBehavior enemyScript = newEnemy.GetComponent<EnemyBehavior>();
        if (enemyScript != null)
        {
            enemyScript.moveSpeed = Random.Range(1.5f, 3.5f);
            enemyScript.moveRange = Random.Range(2f, 5f);
            enemyScript.pulseSpeed = Random.Range(1.5f, 3.5f);
            enemyScript.scaleAmplitude = Random.Range(0.2f, 0.4f);
            enemyScript.circularMotion = (Random.value > 0.5f);
        }
    }
}
