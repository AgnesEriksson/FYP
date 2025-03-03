using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawnables; // Array to store Obstacles
    [SerializeField] private Transform spawnPoint; // The SpawnPoint for the Obstacles
    [SerializeField] private float initialSpawnRate = 2f; // Initial spawn rate
    [SerializeField] private float speedModifier = 1f; // Speed of obstacles
    [SerializeField] private float spawnRateDecrease = 0.05f; // Amount to decrease spawn rate per spawn
    [SerializeField] private float speedIncrease = 0.1f; // Amount to increase speed per spawn
    private float currentSpawnRate;
    private float timeSinceSpawn;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= currentSpawnRate)
        {
            SpawnObject();
            timeSinceSpawn = 0f;

            // Gradually adjust spawn rate and speed with controlled increments
            currentSpawnRate = Mathf.Max(currentSpawnRate - spawnRateDecrease, 0.5f);
            speedModifier += speedIncrease;
        }
    }

    private void SpawnObject()
    {
        GameObject obstacle = Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speedModifier;
    }
}
