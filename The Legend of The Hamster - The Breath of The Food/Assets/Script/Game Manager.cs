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
    public Animator bigboyanim;
    public Animator fridgeAnim;
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

    public void winButton()
    {
        fridgeAnim.SetTrigger("isOpening");
        StartCoroutine(WaitforOneSecond());
        SceneManager.LoadScene("Win Scene");
    }
    public void BigBoyButton()
    {
        bigboyanim.SetTrigger("Dialogue Start");
    }
    public void exitButton()
    {
        Application.Quit();
    }
    IEnumerator WaitforOneSecond()
    {
        yield return new WaitForSeconds(1f);
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
