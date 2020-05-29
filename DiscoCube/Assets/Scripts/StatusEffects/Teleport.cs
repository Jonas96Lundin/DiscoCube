using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject center;
    public Transform teleportTarget;
    public Transform teleportCollider;
    RotatingLevelScript rotateScript;
    Movement movementScript;
    public bool triggerActivated;
    enum TeleportColors { teal, green, yellow, blue, purple, red};
    [SerializeField]
    TeleportColors teleportToColor;

    private void Start()
    {
        rotateScript = FindObjectOfType<RotatingLevelScript>();
        movementScript = FindObjectOfType<Movement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerActivated = true;
        FindObjectOfType<AudioManager>().Play("Teleporter");
    }

    public void Update()
    {
        if (triggerActivated && movementScript.moving == false)
        {
            switch (teleportToColor)
            {
                case TeleportColors.red:
                    rotateScript.rotateToColor = "red";
                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(180, 180, 0))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }
                    break;
                case TeleportColors.teal:
                    rotateScript.rotateToColor = "teal";
                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(0, 0, 0))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }
                    break;
                case TeleportColors.green:
                    rotateScript.rotateToColor = "green";

                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(-90, 0, 0))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }
                    break;
                case TeleportColors.yellow:
                    rotateScript.rotateToColor = "yellow";
                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(0, 0, -90))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }

                    break;
                case TeleportColors.blue:
                    rotateScript.rotateToColor = "blue";
                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(0, 0, -90))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }
                    break;
                case TeleportColors.purple:
                    rotateScript.rotateToColor = "purple";
                    if (rotateScript.cube.transform.rotation == Quaternion.Euler(0, 0, -90))
                    {
                        player.transform.position = teleportTarget.transform.position;
                        triggerActivated = false;
                        center.transform.position = teleportTarget.transform.position;
                    }
                    break;
            }

        }
    }
}
