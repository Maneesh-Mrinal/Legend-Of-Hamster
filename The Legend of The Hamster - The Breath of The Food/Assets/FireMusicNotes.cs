using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMusicNotes : MonoBehaviour
{
    public GameObject[] SpawnPointsArray;
    public GameObject[] AttackTypes;
    public float moveDistance = 2f;
    public void Update()
    {
        StartCoroutine(SpawnNotesinInterval());
    }
    IEnumerator SpawnNotesinInterval()
    {
        GameObject instance = Instantiate(AttackTypes[Random.Range(0,3)], SpawnPointsArray[Random.Range(0,4)].transform.position, Quaternion.identity);
        // Move the instantiated object to the left
        Vector3 leftDirection = -transform.right; // Use the negative right direction to go left
        float distanceToMove = 10f; // Adjust the distance as needed
        instance.transform.Translate(leftDirection * distanceToMove, Space.World);
        yield return new WaitForSeconds(10);
    }
}
