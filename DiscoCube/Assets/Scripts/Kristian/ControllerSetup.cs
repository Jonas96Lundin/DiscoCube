using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerSetup : MonoBehaviour
{
    private bool xboxActivated, pS4Activated;

    public string inputVertical;

    private string xboxVertical, ps4Vertical;



    // Start is called before the first frame update
    void Start()
    {
        
        xboxVertical = "joystick 1 Vertical";

        
        ps4Vertical = "joystick 2 Vertical";

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

    public void XboxControlConfiguration()
    {
        inputVertical = xboxVertical;



    }

    public void PS4ControlConfiguration()
    {
        inputVertical = ps4Vertical;




    }

}
