using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSwitch : MonoBehaviour
{
    WinTrigger winTriggerScrippt;
    public GameObject player;
    public Transform switchTrigger;
    public bool trigger;

    void Start()
    {
        winTriggerScrippt = FindObjectOfType<WinTrigger>();
    }
    public void OnTriggerEnter(Collider other)
    {
        trigger = true;
    }

    void Update()
    {
        if (trigger)
        {
            winTriggerScrippt.steppedOnGoalTrigger = true;
        }
        else
        {
            winTriggerScrippt.steppedOnGoalTrigger = false;
        }
    }
}
