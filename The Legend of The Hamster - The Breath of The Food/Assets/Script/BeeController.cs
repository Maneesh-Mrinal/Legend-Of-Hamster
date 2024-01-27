using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public Transform TargetLoc;
    GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetObject = GameObject.FindWithTag("Player");
        Transform TargetLoc = targetObject.transform;
        GetComponent<AIPath>().target = TargetLoc;
    }
}
