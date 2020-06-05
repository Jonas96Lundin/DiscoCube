using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    //Creator David

    private WinTrigger winTrigger;
    float currentTime = 0f;
    [SerializeField] 
    float totalTime;
    [SerializeField] 
    Text countdownText;
    [HideInInspector]
    public bool isActive; // Jonas kod

    public float Timer
    {
        get { return currentTime; }
    }

    private PauseMenu pauseMenuScript;

    void Start()
    {
        winTrigger = FindObjectOfType<WinTrigger>();
        isActive = true;
        currentTime = totalTime;
        pauseMenuScript = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {

        if (isActive) // Jonas kod
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                isActive = false;
                pauseMenuScript.Restart();
            }
        }
        if (winTrigger.win)
        {
            isActive = false;
        }
    }
}
