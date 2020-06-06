using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    //Creator: David
    //Contribution by: Raimon

    private bool freezeTrapTriggerActivated;
    Movement movementScript;
    float freezeTimer = 0f;

    void Start()
    {
        movementScript = FindObjectOfType<Movement>();
    }

    public void OnTriggerEnter(Collider other)
    {
        freezeTrapTriggerActivated = true;
        FindObjectOfType<AudioManager>().Play("FreezeTrap");
    }
    void Update()
    {
        if (freezeTrapTriggerActivated)
        {
            movementScript.input = false;
            freezeTimer += Time.deltaTime;
            if (freezeTimer > 5f)
            {
                freezeTrapTriggerActivated = false;
                movementScript.input = true;
                freezeTimer = 0f;
            }
        }
    }
}
