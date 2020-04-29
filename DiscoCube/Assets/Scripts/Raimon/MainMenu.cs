using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string levelToLoad;
    [SerializeField]
    SceneFader sceneFader;
    [SerializeField]
    GameObject settingsMenuUI, guideMenuUI;
    [SerializeField]
    Dropdown resolutionDropdown;
    Resolution[] resolutions;
    
    void Start()
    {
        ScreenResolution();
    }

    private void ScreenResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

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

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
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
        if (guideMenuUI == true && Input.GetButtonDown("Cancel"))
        {
            GuideMenuReturn();
            SettingsMenuReturn();
        }
    }

    public void SettingsMenu()
    {
        settingsMenuUI.SetActive(true);
    }

    public void GuideMenu()
    {
        guideMenuUI.SetActive(true);
    }

    public void GuideMenuReturn()
    {
        guideMenuUI.SetActive(false);
    }

    public void SettingsMenuReturn()
    {
        settingsMenuUI.SetActive(false);
    }

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        
    }

    public void Quit()
    {
        Debug.Log("I'm out!");
        Application.Quit();
    }
}
