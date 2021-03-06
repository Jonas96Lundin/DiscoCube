﻿using UnityEngine;

/// <summary>
/// This script is connected to the different trigger points around the level cube.
/// These triggers makes it so that the player cube can roll over the edges of the level cube.
/// 
/// Created by: Kristian & Jonas
/// Contributed by: 
/// </summary>

public class FlipTrigger : MonoBehaviour
{
    [SerializeField]
    public string triggerColor1, triggerColor2;
    string savedTriggerColor1, savedTriggerColor2, oldLevelColor;

    bool triggerActivated;

    Movement moveScript;
    ColorManager colorScript;
    RotatingLevelScript rotateScript;

    void Start()
    {
        moveScript = FindObjectOfType<Movement>();
        colorScript = FindObjectOfType<ColorManager>();
        rotateScript = FindObjectOfType<RotatingLevelScript>();
        savedTriggerColor1 = triggerColor1;
        savedTriggerColor2 = triggerColor2;
        oldLevelColor = colorScript.currentLevelColor.ToString();
    }

    void Update()
    {
        if (triggerActivated && moveScript.moving == false && colorScript.isOnGround == false)
        {
            FlipDirection();
        }

        if(oldLevelColor != colorScript.currentLevelColor.ToString())
        {
            triggerActivated = false;
            oldLevelColor = colorScript.currentLevelColor.ToString();
        }
    }

    /// <summary>
    /// Flips the level to the other side of the fliptrigger object
    /// </summary>
    void FlipDirection()
    {
        if (colorScript.currentLevelColor.ToString() == triggerColor1)
        {
            rotateScript.rotateToColor = triggerColor2;
            moveScript.OnTriggerReset(moveScript.center);   
        }
        else if(colorScript.currentLevelColor.ToString() == triggerColor2)
        {
            rotateScript.rotateToColor = triggerColor1;
            moveScript.OnTriggerReset(moveScript.center);
        }
        triggerActivated = false;
        
    }
    /// <summary>
    /// Edge trigger activated
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        triggerColor1 = savedTriggerColor1;
        triggerColor2 = savedTriggerColor2;
        colorScript.isOnGround = false;
        triggerActivated = true;
    }

    /// <summary>
    /// Resets the trigger colors
    /// </summary>
    public void ResetTriggerColors()
    {
        triggerColor1 = "";
        triggerColor2 = "";
    }
}
