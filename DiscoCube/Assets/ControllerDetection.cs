using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        DetectIfControllerIsConnected();
    }

    private void DetectIfControllerIsConnected() //Script by: Kristian.
    {
        //Checks if the loaded scene is the first level of the game.
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            string[] names = Input.GetJoystickNames();
            for (int x = 0; x < names.Length; x++)
            {
                print(names[x].Length);
                if (names[x].Length == 19)
                {
                    print("PS4 CONTROLLER IS CONNECTED");
                    controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                    ps4.SetActive(true);
                }
                if (names[x].Length == 33)
                {
                    print("XBOX ONE CONTROLLER IS CONNECTED");
                    controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                    xbox.SetActive(true);
                }
                else
                {
                    print("No controller detected!"); // If no controller is connected, the game continues with mouse & keyboard settings.
                    mouseAndKeyboard.SetActive(true);
                    return;
                }
            }
        }
        //This prevents the controller detection from displaying on the main menu.
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            return;
        }
        //If an input device has been chosen in a previous level, then it shall not display in the following levels.
        else
        {

        }
    }

}
