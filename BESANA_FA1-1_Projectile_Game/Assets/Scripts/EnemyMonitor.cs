using UnityEngine;

public class EnemyMonitor : MonoBehaviour
{
    [Header("Settings")]
    public string enemyTag = "Enemy";  // Tag assigned to all enemies
    public int maxEnemies = 12;        // Maximum allowed enemies

    void Update()
    {
        // Count all active enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (enemies.Length > maxEnemies)
        {
            Debug.LogWarning("Too many enemies spawned! Stopping the game.");

            // Stop the game in editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Stop play in build
            Application.Quit();
#endif
        }
    }
}
