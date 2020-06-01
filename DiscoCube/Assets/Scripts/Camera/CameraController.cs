using UnityEngine;

/// <summary>
/// This script enables the player to activate and subsequently take control of the games camera.
/// This will be activated/deactivated with a button press from the player at any time during the game.
/// 
/// Owner: Jonas
/// Code by: Krisitan
/// </summary>

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform levelCenter;
    private Transform cameraTransform;

    [SerializeField]
    Vector3 offset;
    private Vector3 localRotation;

    [SerializeField]
    float mouseSensitivity, scrollSensitivity, orbitDampening, scrollDampening;
    private float cameraDistance = 50f;

    public static string inputRSVertical, inputRSHorizontal;

    public static bool freelookActivated = false;

    private void Start()
    {
        this.cameraTransform = this.transform;
        this.levelCenter = this.levelCenter.transform;
        localRotation = offset;
        if (!ControllerSetup.controllerSelected)
        {
            inputRSVertical = "Xbox RS Vertical";
            inputRSHorizontal = "Xbox RS Horizontal";
        }
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("ActivateCamera"))
        {
            freelookActivated = true;
            localRotation = offset;
        }
        else if(Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0) || Input.GetButtonUp("ActivateCamera"))
        {
            freelookActivated = false;
            localRotation = offset;
        }
        //Rotation of the camera based on Mouse Coordinatied
        if (freelookActivated)
        {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.GetAxis(inputRSHorizontal) != 0 || Input.GetAxis(inputRSVertical) != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                localRotation.x += Input.GetAxis(inputRSHorizontal) * mouseSensitivity;
                localRotation.y -= Input.GetAxis(inputRSVertical) * mouseSensitivity;

                //TODO 
                //Test if Mathf.Clamp works instead.
                //Clamp the y rotation to horizon and not flipping over at the top.
                if (localRotation.y < 0f)
                    localRotation.y = 0f;
                else if (localRotation.y > 90f)
                    localRotation.y = 90f;
            }
         
        }

        //Actual Camera rig transformation
        Quaternion tempQuaterion = Quaternion.Euler(localRotation.y, localRotation.x, 0);

        this.levelCenter.rotation = Quaternion.Lerp(this.levelCenter.rotation, tempQuaterion, Time.deltaTime * orbitDampening);
        
        //Optimization: Makes it so that the process doesn't have to be called if there are no changes.
        if(this.cameraTransform.localPosition.z != this.cameraDistance * -1f)
        {
            this.cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.cameraTransform.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
}
