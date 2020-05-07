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

    public string inputRSVertical, inputRSHorizontal;

    bool freelookActivated = false;

    private void Start()
    {
        this.cameraTransform = this.transform;
        this.levelCenter = this.levelCenter.transform;
        localRotation = offset;
        inputRSVertical = "Xbox RS Vertical";
        inputRSHorizontal = "Xbox RS Horizontal";
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("ActivateCamera"))
        {
            freelookActivated = !freelookActivated;
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
           
            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                //Zooming Input from Mouse Wheel.
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                scrollAmount *= (this.cameraDistance * 0.3f);

                this.cameraDistance += scrollAmount * -1f;

                //this makes the camera go no closer than 1.5 meters from target, and no further than 100 meters.
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, 1.5f, 100f);
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
