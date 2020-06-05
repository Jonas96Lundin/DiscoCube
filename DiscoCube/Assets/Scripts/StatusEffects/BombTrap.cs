using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombTrap : MonoBehaviour
{
    public bool trapTriggerActivated;
    PauseMenu pauseMenuScript;

    void Start()
    {
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
