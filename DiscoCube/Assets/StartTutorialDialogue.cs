using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorialDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START TUTORIAL TRIGGERED");
        FindObjectOfType<ScaleTween>().ScaleUp();
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }
}
