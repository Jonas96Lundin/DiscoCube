using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //Owner: Raimon
    //Code from: David

    public static bool UIExtraMenuActive;
    [SerializeField]
    GameObject settingsMenuUI, guideMenuUI;
    [SerializeField]
    Dropdown resolutionDropdown;
    Resolution[] resolutions;
    MovementScript moveScript;
    void Awake()
    {
        UIExtraMenuActive = false;
    }

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
        UIExtraMenuActive = true;
        settingsMenuUI.SetActive(true);
    }

    public void GuideMenu()
    {
        UIExtraMenuActive = true;
        guideMenuUI.SetActive(true);
    }

    public void GuideMenuReturn()
    {
        UIExtraMenuActive = false;
        guideMenuUI.SetActive(false);
    }

    public void SettingsMenuReturn()
    {
        UIExtraMenuActive = false;
        settingsMenuUI.SetActive(false);
    }
}
