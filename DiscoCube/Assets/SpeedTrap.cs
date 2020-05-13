using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrap : MonoBehaviour
{
    public GameObject player;
    public Transform speedTrap;
    public bool speedTrapTriggerActivated;
    MovementScript movementScript;
    float timer = 0f;

    void Start()
    {
        movementScript = FindObjectOfType<MovementScript>();   
    }
    public void OnTriggerEnter(Collider other)
    {
        speedTrapTriggerActivated = true;
    }

    void Update()
    {
        if (speedTrapTriggerActivated)
        {
            movementScript.speed = 0.1f;
            timer += Time.deltaTime;

            if (timer > 5f)
            {
                speedTrapTriggerActivated = false;
                movementScript.speed = 0.01f;
                timer = 0f;
            }
        }
    }
}
