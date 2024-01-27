using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoo : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public Vector3 spawnLocation;
    public int skullsSpawned = 0;
    public int maxSkullSpawn = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && skullsSpawned <= maxSkullSpawn)
        {
            Instantiate(prefabToInstantiate, spawnLocation, Quaternion.identity);
        }
    }
}
