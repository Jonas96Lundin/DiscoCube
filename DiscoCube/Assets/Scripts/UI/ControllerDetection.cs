using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ControllerDetection checks when the first level is loaded if there is a controller connected. If there is, it shows a controller select overlay.
/// When an inputdevice is chosen, the controller guide in the bottom left corner of the screen displays the chosen input devices controls.
/// 
/// Created by: Kristian
/// </summary>
public class ControllerDetection : MonoBehaviour
{
    [SerializeField]
    GameObject controllerSelectionOverlay;
    [SerializeField]
    GameObject mouseAndKeyboard, xbox, ps4;

    static bool controllerDetected;

    enum inputDevice { noController, xController, pController}
    static inputDevice currentInputDevice;

    string startScene = "Jonas Tutorial", mainMenuScene = "MainMenu";
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == startScene)
            DetectIfControllerIsConnected();
        //Checks if the loaded scene is the first level of the game and if the tutorial is skipped.
        //If an input device has been chosen in Levl1, then it shall keep displaying in the following levels.
        else if (SceneManager.GetActiveScene().name != mainMenuScene)
        {
            DisplayCorrectInputOverlay();
        }
        //This prevents the controller detection from displaying on the main menu.
        else
            return;
    }

    private void DetectIfControllerIsConnected() //Method by: Kristian.
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            Debug.Log(names[x].Length);
            if (names[x].Length == 19)//19 equals the number of characters in Playstation 4 controllers Unity name.
            {
                controllerDetected = true;
                controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                ps4.SetActive(true);
                currentInputDevice = inputDevice.pController;
            }
            else if (names[x].Length == 33)//33 equals the number of characters in Xbox One controllers Unity name.
            {
                controllerDetected = true;
                controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                xbox.SetActive(true);
                currentInputDevice = inputDevice.xController;
            }
        }

        if (!controllerDetected)
        {
            // If no controller is connected, the game continues with mouse & keyboard settings.
            mouseAndKeyboard.SetActive(true);
            currentInputDevice = inputDevice.noController;
            return;
        }
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

                break;


            case inputDevice.pController:

                ps4.SetActive(true);

                break;
        }
    }
}
