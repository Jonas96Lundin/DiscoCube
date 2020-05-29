using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// A manager that handles Dialogues. 
/// Created by: Jonas
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    [SerializeField]
    GameObject wrongColorTutorial;

    [SerializeField]
    bool secondVoice;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0)/*GetKeyDown(KeyCode.Return)*/)
        {
            DisplayNextSentence();
        }
        if(sentences.Count > 0)
        {
            CountUpTimer.IsCounting = false;
        }
    }

    /// <summary>
    /// Start the dialogue.
    /// Method by: Jonas
    /// </summary>
    /// <param name="dialogue">The dialogue you want to start</param>
    public void StartDialogue(Dialogue dialogue)
    {
        CountUpTimer.IsCounting = false;
        FindObjectOfType<Movement>().canMove = false;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    /// <summary>
    /// Displays the next sentence in the Dialogue, if sentences is zero, end dialogue.
    /// Created by: Jonas
    /// </summary>
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    /// <summary>
    /// Type the sentence so it looks like someone is writing the text, letter by letter. Also plays a sound for each letter.
    /// Created by: Jonas
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        int soundCounter = 50;
        foreach (char letter in sentence.ToCharArray())
        {
            if (secondVoice)
            {
                if (soundCounter % 50 == 0)
                {
                    FindObjectOfType<AudioManager>().Play("SenseiTalk");
                }
                soundCounter++;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("SenseiTalkBitDemon");
            }
            dialogueText.text += letter;
            yield return null;
        }
    }
    /// <summary>
    /// Scales down objects and starts the timer.
    /// Created by: Jonas
    /// </summary>
    private void EndDialogue()
    {
        GameObject[] tutorialDialogueObjects = GameObject.FindGameObjectsWithTag("TutorialDialogue");
        foreach (GameObject gameObject in tutorialDialogueObjects)
        {
            FindObjectOfType<ScaleTween>().ScaleDown();

        }
        CountUpTimer.IsCounting = true;
        FindObjectOfType<Movement>().canMove = true;
        wrongColorTutorial.SetActive(true);
        StopAllCoroutines();
        //FindObjectOfType<AudioManager>().Stop("SenseiTalkBitDemon");
        //FindObjectOfType<AudioManager>().Stop("SenseiTalk");

    }
}
