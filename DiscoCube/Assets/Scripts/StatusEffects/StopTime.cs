using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    private WinTrigger winTrigger;
    public GameObject player;
    public Transform time;
    public bool stopTimeTriggerActivated;
    CountdownTimer countDownTimer;
    float stopTimeCounter = 0;

    void Start()
    {
        winTrigger = FindObjectOfType<WinTrigger>();
        countDownTimer = FindObjectOfType<CountdownTimer>();
    }
    public void OnTriggerEnter(Collider other)
    {
        stopTimeTriggerActivated = true;
        FindObjectOfType<AudioManager>().Play("TimeStop");
    }

    void Update()
    {
        if (stopTimeTriggerActivated)
        {
            countDownTimer.isActive = false;
            stopTimeCounter += Time.deltaTime;
            if (stopTimeCounter > 5f)
            {
                stopTimeTriggerActivated = false;
                countDownTimer.isActive = true;
                stopTimeCounter = 0f;
            }
        }

        if (winTrigger.win)
        {
            countDownTimer.isActive = false;
        }
    }
}
