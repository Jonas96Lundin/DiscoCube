using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSetup : MonoBehaviour
{
    Movement_Side_Change moveScript;
    FollowPlayer cameraScript;
    
    private bool xboxActivated, pS4Activated;

    private string xboxVertical, xboxHorizontal, xboxRSVertical, xboxRSHorizontal, ps4Vertical, ps4Horizontal, ps4RSVertical, ps4RSHorizontal;


    // Start is called before the first frame update
    void Start()
    {
        moveScript = FindObjectOfType<Movement_Side_Change>();
        cameraScript = FindObjectOfType<FollowPlayer>();

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
        if (xboxActivated)
        {
            XboxControlConfiguration();
            pS4Activated = false;
        }
        else if (pS4Activated)
        {
            PS4ControlConfiguration();
            xboxActivated = false;
        }
        else
            return;
    }

    //TODO: Fix it so that when you have both types of controllers plugged in. They will not interfere with one another. 
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

}
