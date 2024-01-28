using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public GameObject HelpSign;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(WaitForTimeGiven());
        }
    }
    IEnumerator WaitForTimeGiven()
    {
        yield return new WaitForSeconds(waitTime);
        HelpSign.SetActive(true);
    }
}
