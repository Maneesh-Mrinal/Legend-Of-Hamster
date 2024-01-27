using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBee : MonoBehaviour
{
    public GameObject BeePrefab;
    public float timebtwSpawn = 30f;
    public int maxBees = 3;
    public int spawnedBeeCount = 0;
    public float spawnTimer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer += Time.fixedDeltaTime;

        if (spawnTimer > timebtwSpawn && spawnedBeeCount < 3)
        {
            spawnTimer = 0f;
            SpawnBeePref();
            
        }
    }
    void SpawnBeePref()
    {
        // Instantiate the prefab
        GameObject newPrefab = Instantiate(BeePrefab, transform.position, Quaternion.identity);

        // Increment the count
        spawnedBeeCount++;

        // Optionally, you can do something with the instantiated prefab (e.g., position it, modify its properties, etc.)
        // newPrefab.transform.position = ...

        // You can also destroy the instantiated prefab after a certain time if needed
        // Destroy(newPrefab, 10f);
    }
    void DecreaseSpawnCount()
    {
        spawnedBeeCount--;
    }
}
