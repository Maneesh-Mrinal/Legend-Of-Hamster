using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isFirstTime = true;
    public float timer = 0f;
    public bool isCutScene1 = false;
    public void playButton()
    {
        if (isFirstTime == true)
        {
            isFirstTime = false;
            SceneManager.LoadScene("CutScene Start");
        }
        else
        {
            SceneManager.LoadSceneAsync("Level Lawn");
        }
    }
    private void FixedUpdate()
    {
        if(isCutScene1 == false)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "CutScene Start")
            {
                isCutScene1 = true;
                StartCoroutine(WaitForCutSceneOne());
            }
        }
    }
    public void exitButton()
    {
        Application.Quit();
    }
    IEnumerator WaitForCutSceneOne()
    {
        yield return new WaitForSeconds(60f);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
