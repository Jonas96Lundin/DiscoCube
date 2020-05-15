using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombTrap : MonoBehaviour
{
    public GameObject player;
    public Transform trap;
    public bool trapTriggerActivated;
    SceneFader sceneFader;
    StepCounter stepCounterScript;
    PauseMenu pauseMenuScript;

    void Start()
    {
        stepCounterScript = FindObjectOfType<StepCounter>();
        pauseMenuScript = FindObjectOfType<PauseMenu>();
    }

    public void OnTriggerEnter(Collider other)
    {
        trapTriggerActivated = true;
        FindObjectOfType<AudioManager>().Play("BombTrap");
    }

    void Update()
    {
        if (trapTriggerActivated)
        {
            pauseMenuScript.Restart();
        }
    }
}
