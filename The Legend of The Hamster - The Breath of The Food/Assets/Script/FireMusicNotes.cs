using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMusicNotes : MonoBehaviour
{
    public GameObject[] SpawnPointsArray;
    public GameObject[] AttackTypes;
    private int randPoint;
    private int randPrefab;
    private bool isSpawned = false;
    public float timeBtwSpawn;
    public void Update()
    {
        randPoint = Random.Range(0,SpawnPointsArray.Length);
        randPrefab = Random.Range(0, AttackTypes.Length);
        if (isSpawned == false)
        {
            isSpawned = true;
            StartCoroutine(SpawnNotes());
        }
    }
    IEnumerator SpawnNotes()
    {
        Instantiate(AttackTypes[randPrefab], SpawnPointsArray[randPoint].transform.position, Quaternion.identity);

        yield return new WaitForSeconds(timeBtwSpawn);

        isSpawned = false;
    }
}
