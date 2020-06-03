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
    
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F5))
        {
            NextScene();
        }
    }
    public void NextScene()
    {
        sceneFader.FadeTo(levelToLoad);
    }
    public void ToMainMenu()
    {
        sceneFader.FadeTo("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
