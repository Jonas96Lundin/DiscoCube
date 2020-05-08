using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Owner: Raimon
    //Code from: David


    public static bool symbolSwitch;
    [SerializeField]
    string levelToLoad;
    [SerializeField]
    SceneFader sceneFader;
    string mainMenu = "MainMenu";
    
    public void NextScene()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
