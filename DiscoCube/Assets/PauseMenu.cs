using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject guideMenuUI;

    public Dropdown resolutionDrowdown;
    Resolution[] resolutions;


    void Start()
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void SetVolume(float volume)
    {

    }
    public void SetFullscren(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StepCounter.stepCounter = 0;
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
    public void Return()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
