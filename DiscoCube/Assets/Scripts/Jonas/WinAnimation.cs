﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class WinAnimation : MonoBehaviour
{
    Vector3 endPos, endPosOrientation;
    float moveSpeed, animationDelay;
    bool isWinning, ActivateWinAnimation, steppedOnGoalTrigger;
    string currentColor, currentWinningColor, oldColor;

    [SerializeField]
    ColorManager colorManager;

    [SerializeField]
    GameObject completeLevelUI;

    [SerializeField]
    ColorManager.LevelColors winColor;



    // Start is called before the first frame update
    public void Start()
    {
        isWinning = ActivateWinAnimation = false;

        // Declares start and end position for the cube win movement
        endPosOrientation = new Vector3(0, -4, 0);
        endPos = transform.position + endPosOrientation;
        completeLevelUI.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        currentColor = colorManager.currentColor.ToString();
        currentWinningColor = colorManager.currentWinningColor.ToString();

        //Jonas
        if (steppedOnGoalTrigger)
        {
            if (colorManager.currentLevelColor == winColor && currentColor == currentWinningColor)
            {
                animationDelay = 0;
                //TODO           
                //Lås movement så att man inte kan fortsätta röra på sig efter victory animation har påbörjats. Koordinera med Kristians movement script.
                ActivateWinAnimation = true;
            }
            else if(!(colorManager.currentLevelColor == winColor && currentColor == currentWinningColor) && !ActivateWinAnimation)
            {
                FindObjectOfType<WrongColorDialogue>().DialoguePopUp();
            }
        }
        //Jonas
        if (oldColor != currentColor)
        {
            steppedOnGoalTrigger = false;
        }

        // TODO: When the Restart function is called, the winning trigger is never activated.
        if (!isWinning && ActivateWinAnimation)
        {
            endPos = transform.position + endPosOrientation;
            isWinning = true;
        }
        if (isWinning)
        {
            moveSpeed += 0.01f; //Adjust this for how fast you want the cube to fall into the hole.
            transform.position = Vector3.Lerp(transform.position, endPos, moveSpeed);

            //Rasmus kod:
            animationDelay += 1 * Time.deltaTime;

            if (transform.position==endPos) // jonas kod
            {
                colorManager.SetGlowingColors(winColor);
            }
            // Rasmus kod
            if (ActivateWinAnimation && animationDelay >= 2f)
            {
                Win();
                animationDelay = 0;
            }
        }

    }
    public void SetOrientation(Vector3 orientation)
    {
        endPosOrientation = orientation;

    }
    // Rasmus kod:
    public void OnTriggerEnter(Collider collision)
    {
        //Jonas
        if (collision.gameObject.tag == "Goal")
        {
            steppedOnGoalTrigger = true;
            oldColor = currentColor;
        }
    }

    public void Win()
    {
        completeLevelUI.SetActive(true);
    }
}
