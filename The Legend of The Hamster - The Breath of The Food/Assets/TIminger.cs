using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIminger : MonoBehaviour
{
    public float time = 10f;
    //private static float a = time;
    private bool b = true;

    private GameObject T = GameObject.Find("Dialog").GetComponent<GameObject>();

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            StartCoroutine(MyCoroutine());
            display();
        }

    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(30); // Wait for 3 seconds
        //Debug.Log("Coroutine finished after 3 seconds");
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            b = false;
            // a = time;
            Debug.Log("n");
        }
    }

    private void display()
    {
        if (b)
        {
            T.SetActive(true);
            b = false;
            //a = time;
        }
    }

    private void reset()
    {
        T.SetActive(false);
    }
}

