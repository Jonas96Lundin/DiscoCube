using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A trigger that sends and starts the dialogue in DialogueManger
/// Created by: Jonas
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
