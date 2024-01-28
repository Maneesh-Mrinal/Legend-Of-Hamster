using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    GameObject targetObject;
    public Vector2 targetLocation = Vector2.zero;
    public int damageDealt = 1;
    public float timeToDestroy = 15f;
    void Start()
    {
        targetObject = GameObject.FindWithTag("Player");
        targetLocation = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetLocation,
            moveSpeed * Time.deltaTime
            );
        StartCoroutine(WaitforTSeconds());
    }
    IEnumerator WaitforTSeconds()
    {
        yield return new WaitForSeconds( timeToDestroy );
        Destroy(gameObject);
    }
}
