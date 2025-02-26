using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Spawnables; //Array to store Obstacles
    [SerializeField] private Transform spawnPoint; //The SpawnPoint for the Obstacles
    [SerializeField] private float spawnRate = 2f; // How fast the Obstacles Spawn Serialized so easily changed
    [SerializeField] public float speedModifier = 1f; // To be use to speed up obstacles and spawning

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnRate * speedModifier); //Starts Spawn Cyle at Spawn Rate
    }

    private void SpawnObject()
    {
        GameObject obstacle = Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], spawnPoint.position, Quaternion.identity); // Instantiates from give array
        Rigidbody2D oRB = obstacle.GetComponent<Rigidbody2D>();
        oRB.velocity = Vector2.left * speedModifier;
    }
}
