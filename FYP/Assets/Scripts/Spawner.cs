using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawnables; //Array to store Obstacles
    [SerializeField] private Transform spawnPoint; //The SpawnPoint for the Obstacles
    [SerializeField] private float spawnRate = 2f; // How fast the Obstacles Spawn Serialized so easily changed
    [SerializeField] public float speedModifier = 1f; // To be use to speed up obstacles and spawning
    private float timeSinceSpawn;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnRate * speedModifier); //Starts Spawn Cyle at Spawn Rate
    }

    private void Update()
    {
        SpawnObject(); // Checks to see if spawn conditionas are met every frame
    }

    private void SpawnObject()
    {
        timeSinceSpawn += Time.deltaTime; //enumaterates the spawn time every secnd
        if (timeSinceSpawn >= spawnRate) // time since last spawn is greatere than the spawn rate triggers the spawn cycles and zeros it 
        {
            Spawn();
            timeSinceSpawn = 0f;
        }
/*        GameObject obstacle = Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], spawnPoint.position, Quaternion.identity); // Instantiates from give array
        Rigidbody2D oRB = obstacle.GetComponent<Rigidbody2D>();
        oRB.velocity = Vector2.left * speedModifier;*/
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], spawnPoint.position, Quaternion.identity); // Instantiates from give array
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speedModifier;
    }
}
