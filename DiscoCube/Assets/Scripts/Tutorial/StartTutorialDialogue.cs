using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Start the tutorial dialogue
/// Created by: Jonas
/// </summary>
public class StartTutorialDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    bool isStarted;
    void Update()
    {
        if (!isStarted)
        {
            Debug.Log("START TUTORIAL TRIGGERED");
            FindObjectOfType<ScaleTween>().ScaleUp();
            FindObjectOfType<DialogueTrigger>().TriggerDialogue();
            isStarted = true;
        }
    }


}
