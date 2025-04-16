using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit called (Editor won't quit)");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
