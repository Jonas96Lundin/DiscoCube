using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
   
    private void Awake()
    {
        //Checks if the loaded scene is the first level of the game.
        if (SceneManager.GetActiveScene().name == "Level1")
            DetectIfControllerIsConnected();
        //If an input device has been chosen in Levl1, then it shall keep displaying in the following levels.
        else if (SceneManager.GetActiveScene().name != "Level1" || SceneManager.GetActiveScene().name != "MainMenu")
        {
            Debug.Log(currentInputDevice);
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
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                controllerDetected = true;
                
                print("PS4 CONTROLLER IS CONNECTED");
                controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                ps4.SetActive(true);
                currentInputDevice = inputDevice.pController;
            }
            else if (names[x].Length == 33)
            {
                controllerDetected = true;
                print("XBOX ONE CONTROLLER IS CONNECTED");
                controllerSelectionOverlay.SetActive(true); //Displays the controller selection overlay.
                xbox.SetActive(true);
                currentInputDevice = inputDevice.xController;
            }
               
        }

        if (!controllerDetected)
        {
            print("No controller detected!"); // If no controller is connected, the game continues with mouse & keyboard settings.
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
