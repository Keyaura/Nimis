using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadSceneAsync(1);


    }
    public void SkipButton()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
