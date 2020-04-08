﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour
{

    public GameObject triggerGO;
    public GameObject center;
    public string triggerColor1;
    public string triggerColor2;
    string oldTriggerColor;
    //Movement_Side_Change msc = GameObject.FindObjectOfType<Movement_Side_Change>();

    private bool activated;
    private bool ready;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (activated && FindObjectOfType<Movement_Side_Change>().movning == false)
        {
            oldTriggerColor = FindObjectOfType<ColorManager>().currentLevelColor.ToString();
            Debug.Log(oldTriggerColor);
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        if(FindObjectOfType<ColorManager>().currentLevelColor.ToString() == triggerColor1)
        {
            activated = false;
            FindObjectOfType<RotatingScript>().rotateToColor = triggerColor2;
            FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
            Debug.Log("I just flipped to " + triggerColor2);
            
        }
        else if(FindObjectOfType<ColorManager>().currentLevelColor.ToString() == triggerColor2)
        {
            activated = false;
            FindObjectOfType<RotatingScript>().rotateToColor = triggerColor1;
            FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
            Debug.Log("I just flipped to " + triggerColor1);
        }
        Debug.Log("I just flipper my center!");
        activated = false;
        Debug.Log("Unactivated!");
    }
    
    void OnTriggerEnter(Collider other)
    {
        
        activated = true;
        Debug.Log("Activated!");
        if(FindObjectOfType<Movement_Side_Change>().movning==false && oldTriggerColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString())
        {
            activated = false;
        }
    }

    
}
