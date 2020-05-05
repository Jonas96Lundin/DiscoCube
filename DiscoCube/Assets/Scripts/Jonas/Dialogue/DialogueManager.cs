using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    [SerializeField]
    GameObject wrongColorTutorial;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<CountdownTimer>().isActive = false;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        int soundCounter = 50;
        foreach (char letter in sentence.ToCharArray())
        {
            if (soundCounter % 50 == 0)
            {
                FindObjectOfType<AudioManager>().Play("SenseiTalk");
            }
            soundCounter++;
            //FindObjectOfType<AudioManager>().Play("SenseiTalkBitDemon");
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        GameObject[] tutorialDialogueObjects = GameObject.FindGameObjectsWithTag("TutorialDialogue");
        foreach (GameObject gameObject in tutorialDialogueObjects)
        {
            FindObjectOfType<ScaleTween>().ScaleDown();

        }
        FindObjectOfType<CountdownTimer>().isActive = true;
        wrongColorTutorial.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("SenseiTalkBitDemon");

    }
}
