using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScript : MonoBehaviour
{
    public string nextScene;
    public GameObject InteractButton;
    public GameObject PlayerChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EButton();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            InteractButton.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractButton.SetActive(false);
        }
    }
    public void EButton()
    {
        SceneManager.LoadScene(nextScene);
        PlayerChar.gameObject.GetComponent<PlayerMovement>().SavePlayer();
    }
}
