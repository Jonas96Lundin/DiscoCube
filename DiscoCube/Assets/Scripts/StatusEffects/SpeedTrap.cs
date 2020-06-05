using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrap : MonoBehaviour
{
    //Creator David
    //Contributors Raimon
    private bool speedTrapTriggerActivated;
    Movement movementScript;
    float timer = 0f;

    void Start()
    {
        movementScript = FindObjectOfType<Movement>();   
    }
    public void OnTriggerEnter(Collider other)
    {
        speedTrapTriggerActivated = true;
        FindObjectOfType<AudioManager>().Play("SlowTrap");
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
