using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Owner: Raimon
    //Code from: David

    [SerializeField]
    string levelToLoad;
    [SerializeField]
    SceneFader sceneFader;
    
    public void NextScene()
    {
        sceneFader.FadeTo(levelToLoad);

    }

    public void Quit()
    {
        Application.Quit();
    }

}
