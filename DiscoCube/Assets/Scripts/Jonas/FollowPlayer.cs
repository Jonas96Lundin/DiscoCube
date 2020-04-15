
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Transform levelCenter;
    private Transform cameraTransform;

    public Vector3 offset;
    private Vector3 localRotation;

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;
    private float cameraDistance = 50f;

    public bool freelookActivated = false;

    private void Start()
    {
        this.cameraTransform = this.transform;
        this.levelCenter = this.levelCenter.transform;
        localRotation = new Vector3(30,20,-10);
        //BehindPlayer();
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Return))
    //    {
    //        RevolveAroundLevel();
    //    }
    //    else
    //    {
    //        BehindPlayer();
    //    }
        
    //    Zoom();
    //}

    private void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("ActivateCamera"))
        {
            freelookActivated = !freelookActivated;
            localRotation = new Vector3(30, 20, -10);
        }
        //Rotation of the camera based on Mouse Coordinatied
        if (!freelookActivated)
        {
            if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("RightHorizontal") != 0 || Input.GetAxis("RightVertical") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                localRotation.x += Input.GetAxis("RightHorizontal") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("RightVertical") * mouseSensitivity;

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

                //this maled the camera go no closer than 1.5meters from target, and no further than 100 meters.
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, 1.5f, 100f);
            }
        }

        //Actual Camera rid transformation
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);

        this.levelCenter.rotation = Quaternion.Lerp(this.levelCenter.rotation, QT, Time.deltaTime * orbitDampening);

        if(this.cameraTransform.localPosition.z != this.cameraDistance * -1f)
        {
            this.cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.cameraTransform.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
    }
    //private void Zoom()
    //{
    //    if(Input.mouseScrollDelta.y > 0)
    //    {
    //        offset.z++;
    //    }
    //    else if(Input.mouseScrollDelta.y < 0)
    //    {
    //        offset.z--;
    //    }
    //}

    //private void BehindPlayer()
    //{
    //    transform.position = player.position + offset;
    //    transform.rotation = Quaternion.Euler(15, 0, 0);
    //}
    
}
