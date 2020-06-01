using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// This script enables the player to choose which input schematic they want to use.
/// At the start of the game, the game will detect if there are any gamepad/controllers plugged in,
/// and will display a prompt to choose a controller-scheme between Playstation 4's DualShock 4 or Xbox One's Controller.
///
/// Owner: Kristian
/// </summary>

public class ControllerSetup : MonoBehaviour
{
    Movement moveScript;
    CameraController cameraScript;

    [SerializeField]
    GameObject controllerSetupUI, controllerSelectionOverlay;

    [SerializeField]
    GameObject menuFirstButton;

    [SerializeField]
    GameObject mouseAndKeyboard, xbox, ps4;
    enum inputDevice { noController, xController, pController }
    static inputDevice currentInputDevice;

    public static bool xboxActivated, pS4Activated, controllerSelected = false, controllerDetected;

    private static string xboxVertical, xboxHorizontal, xboxRSVertical, xboxRSHorizontal;
    private static string ps4Vertical, ps4Horizontal, ps4RSVertical, ps4RSHorizontal;

    string startScene = "Jonas Tutorial";

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == startScene)
        {
            Time.timeScale = 0f;
            DetectIfControllerIsConnected();
            if (controllerDetected)
            {
                ControllerSelection();
            }
        }
        //This prevents the controller detection from displaying on the main menu.
        else
            return;
    }

    private void ControllerSelection()
    {
        //Time.timeScale = 0f;
        Initialize();
        moveScript.input = false;
        //Clear selected object in event system.
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new object in event system.
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }


    public void Initialize()
    {
        controllerSetupUI.SetActive(true);

        moveScript = FindObjectOfType<Movement>();
        cameraScript = FindObjectOfType<CameraController>();

        // This assignes the controller-differences in input. Some inputs are the same between the
        // different controllers, but some are assigned to different functions on the controller.
        xboxVertical = "Xbox Vertical";
        xboxHorizontal = "Xbox Horizontal";
        xboxRSVertical = "Xbox RS Vertical";
        xboxRSHorizontal = "Xbox RS Horizontal";
        

        ps4Vertical = "PS4 Vertical";
        ps4Horizontal = "PS4 Horizontal";
        ps4RSVertical = "PS4 RS Vertical";
        ps4RSHorizontal = "PS4 RS Horizontal";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DisplayCorrectInputOverlay();
        
        if (controllerSelected)
        {
            return;
        }
        


        
        
        // If the Xbox controll-scheme is selected, the inputs will be configured for Xbox.
        if (xboxActivated)
        {
            XboxControlConfiguration();
            controllerSetupUI.SetActive(false);
            moveScript.input = true;
            controllerSelected = true;
            xbox.SetActive(true);
            currentInputDevice = inputDevice.xController;
            Time.timeScale = 1f;
            
        }
        // If the PS4 controll-scheme is selected, the inputs will be configured for PS4.
        else if (pS4Activated)
        {
            PS4ControlConfiguration();
            controllerSetupUI.SetActive(false);
            moveScript.input = true;
            controllerSelected = true;
            ps4.SetActive(true);
            currentInputDevice = inputDevice.pController;
            Time.timeScale = 1f;
        }
        else
            return;

        if (controllerDetected == false)
        {
            Debug.Log("PC OVERLAY!");
            // If no controller is connected, the game continues with mouse & keyboard settings.
            mouseAndKeyboard.SetActive(true);
            currentInputDevice = inputDevice.noController;
            return;
        }
    }

    public void XboxControlConfiguration()
    {
        Movement.inputVertical = xboxVertical;
        Movement.inputHorizontal = xboxHorizontal;
        CameraController.inputRSVertical = xboxRSVertical;
        CameraController.inputRSHorizontal = xboxRSHorizontal;
    }

    public void PS4ControlConfiguration()
    {
        Movement.inputVertical = ps4Vertical;
        Movement.inputHorizontal = ps4Horizontal;
        CameraController.inputRSVertical = ps4RSVertical;
        CameraController.inputRSHorizontal = ps4RSHorizontal;
    }

    public void OnClickActivatePS4()
    {
        pS4Activated = true;
        xboxActivated = false;
    }

    public void OnClickActivateXbox()
    {
        xboxActivated = true;
        pS4Activated = false;
    }

    public void BackButton()
    {
        controllerSetupUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void DisplayCorrectInputOverlay() //Method by: Kristian.
    {
        //If an input device has been chosen in Level1, then it shall keep displaying in the following levels.
        switch (currentInputDevice)
        {
            case inputDevice.noController:

                mouseAndKeyboard.SetActive(true);

                break;

            case inputDevice.xController:

                xbox.SetActive(true);
                mouseAndKeyboard.SetActive(false);

                break;


            case inputDevice.pController:

                ps4.SetActive(true);
                mouseAndKeyboard.SetActive(false);
                break;
        }
    }

    private void DetectIfControllerIsConnected() //Method by: Kristian.
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)//19 equals the number of characters in Playstation 4 controllers Unity name.
            {
                Debug.Log("19 Detected!");
                controllerDetected = true; 
            }
            else if (names[x].Length == 33)//33 equals the number of characters in Xbox One controllers Unity name.
            {
                Debug.Log("33 Detected!");
                controllerDetected = true;       
            }
            else
            {
                Debug.Log("0 Detected!");
                controllerDetected = false;
                Time.timeScale = 1f;
            }
            Debug.Log("ControllerDetected = " + controllerDetected);
            return;
        }
        
    }

}
