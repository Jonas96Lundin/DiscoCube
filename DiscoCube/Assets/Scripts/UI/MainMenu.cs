using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour
{
    //Owner: Raimon
    //Code from: David

    public static bool UIExtraMenuActive;
    [SerializeField]
    GameObject settingsMenuUI, guideMenuUI, codeInputUI, quitMenuUI,
        settingsActiveButton, guideActiveButton, quitMenuActiveButton;

    [SerializeField]
    Dropdown resolutionDropdown;
    Resolution[] resolutions;
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
        SetActiveButton(settingsActiveButton);
    }

    public void GuideMenu()
    {
        UIExtraMenuActive = true;
        guideMenuUI.SetActive(true);
        SetActiveButton(guideActiveButton);

    }

    public void CodeInputMenu()
    {
        UIExtraMenuActive = true;
        codeInputUI.SetActive(true);
    }

    public void QuitMenu()
    {
        UIExtraMenuActive = true;
        quitMenuUI.SetActive(true);
        SetActiveButton(quitMenuActiveButton);
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

    public void CodeInputMenuReturn()
    {
        UIExtraMenuActive = false;
        codeInputUI.SetActive(false);
    }

    public void QuitMenuReturn()
    {
        UIExtraMenuActive = false;
        quitMenuUI.SetActive(false);
    }
    private void SetActiveButton(GameObject button)
    {
        //Clear selected object.
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new object
        EventSystem.current.SetSelectedGameObject(button);
    }
}
