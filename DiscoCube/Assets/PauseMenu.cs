using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject guideMenuUI;

    StepCounter stepCounterScript;

    public Dropdown resolutionDrowdown;
    Resolution[] resolutions; 


    void Start()
    {
        ScreenResolution();
        stepCounterScript = FindObjectOfType<StepCounter>();
    }

    private void ScreenResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDrowdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDrowdown.AddOptions(options);
        resolutionDrowdown.value = currentResolutionIndex;
        resolutionDrowdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscren(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Menu"))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(guideMenuUI == true && Input.GetButtonDown("Cancel"))
        {
            GuideMenuReturn();
            SettingsMenuReturn();
        }
    }

    public void SetVolume(float volume)
    {
        // TODO 
        // Connect music to method
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        guideMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        guideMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        SceneManager.LoadScene(/*SceneManager.GetActiveScene().name*/"Master");
        stepCounterScript.stepCounter = 0;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);

    }

    public void GuideMenu()
    {
        pauseMenuUI.SetActive(false);
        guideMenuUI.SetActive(true);
    }

    public void GuideMenuReturn()
    {
        pauseMenuUI.SetActive(true);
        guideMenuUI.SetActive(false);
    }

    public void SettingsMenuReturn()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
