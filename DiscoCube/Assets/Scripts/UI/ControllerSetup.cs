using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This script enables the player to choose which input schematic they want to use.
/// At the start of the game, the game will detect if there are any gamepad/controllers plugged in,
/// and will display a prompt to choose a controller-scheme between Playstation 4's DualShock 4 or Xbox One's Controller.
///
/// Owner: Kristian
/// </summary>

public class ControllerSetup : MonoBehaviour
{
    MovementScript moveScript;
    CameraController cameraScript;

    [SerializeField]
    GameObject controllerSetupUI;

    [SerializeField]
    GameObject menuFirstButton;


    public bool xboxActivated, pS4Activated;

    private string xboxVertical, xboxHorizontal, xboxRSVertical, xboxRSHorizontal, ps4Vertical, ps4Horizontal, ps4RSVertical, ps4RSHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        Initialize();
        moveScript.input = false;
        //Clear selected object.
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);

    }

    public void Initialize()
    {
        moveScript = FindObjectOfType<MovementScript>();
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
    void Update()
    {
        // If the Xbox controll-scheme is selected, the inputs will be configured for Xbox.
        if (xboxActivated)
        {
            Debug.Log("Xbox controller activated!");
            XboxControlConfiguration();
            pS4Activated = false;
            controllerSetupUI.SetActive(false);
            Time.timeScale = 1f;
            moveScript.input = true;
            Debug.Log("Timescale = 1");
        }
        // If the PS4 controll-scheme is selected, the inputs will be configured for PS4.
        else if (pS4Activated)
        {
            Initialize();
            Debug.Log(moveScript.inputVertical + " " + moveScript.inputVertical.ToString());

            PS4ControlConfiguration();
            xboxActivated = false;
            controllerSetupUI.SetActive(false);
            moveScript.input = true;
            Time.timeScale = 1f;
        }
        else
            return;
    }

    public void XboxControlConfiguration()
    {
        moveScript.inputVertical = xboxVertical;
        moveScript.inputHorizontal = xboxHorizontal;
        cameraScript.inputRSVertical = xboxRSVertical;
        cameraScript.inputRSHorizontal = xboxRSHorizontal;
    }

    public void PS4ControlConfiguration()
    {
        moveScript.inputVertical = ps4Vertical;
        moveScript.inputHorizontal = ps4Horizontal;
        cameraScript.inputRSVertical = ps4RSVertical;
        cameraScript.inputRSHorizontal = ps4RSHorizontal;
    }

    public void OnClickActivatePS4()
    {
        pS4Activated = true;
    }

    public void OnClickActivateXbox()
    {
        xboxActivated = true;
    }

    public void BackButton()
    {
        controllerSetupUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
