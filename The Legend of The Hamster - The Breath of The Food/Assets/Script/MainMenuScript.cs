using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private bool isFirstTime = true;
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
