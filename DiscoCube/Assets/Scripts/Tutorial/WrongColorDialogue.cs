using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A pop up message when the player is going on the hole with the wrong color
/// Created by: Jonas
/// </summary>
public class WrongColorDialogue : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;
    private float timer;
    private bool isTimerActive;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in objects)
        {
            go.transform.localScale = new Vector3(0, 0, 0);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerActive)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                foreach (GameObject go in objects)
                {
                    LeanTween.scale(go, new Vector3(0, 0, 0), 0.3f).setDelay(1);
                }
                isTimerActive = false;
                timer = 0;
            }
        }
    }

    public void DialoguePopUp()
    {
        foreach (GameObject go in objects)
        {
            LeanTween.scale(go, new Vector3(1, 1, 1), 0.3f);
            isTimerActive = true;
        }
    }
}
