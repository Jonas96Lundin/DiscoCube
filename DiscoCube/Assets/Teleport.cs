using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform teleportTarget;
    public Transform teleportCollider;
    RotatingLevelScript rotateScript;
    MovementScript movementScript;
    public bool triggerActivated;
    Vector3 pos = new Vector3(0, 20, 0);
    Quaternion rot = Quaternion.Euler(180, 180, 0); 

    private void Start()
    {
        rotateScript = FindObjectOfType<RotatingLevelScript>();
        movementScript = FindObjectOfType<MovementScript>();
    }

    public void OnTriggerEnter(Collider other)
    {
        triggerActivated = true;
    }

    public void Update()
    {
        if (triggerActivated && movementScript.movning == false)
        {
            rotateScript.rotateToColor = "red";
            if (rotateScript.cube.transform.rotation == Quaternion.Euler(180, 180, 0))
            {
                player.transform.position = teleportTarget.transform.position;
                triggerActivated = false;   
            }
        }

    }
}
