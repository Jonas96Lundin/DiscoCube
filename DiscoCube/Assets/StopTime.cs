using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public GameObject player;
    public Transform time;
    public bool stopTimeTriggerActivated;
    CountdownTimer countDownTimer;
    float stopTimeCounter = 0;

    void Start()
    {
        countDownTimer = FindObjectOfType<CountdownTimer>();
    }
    public void OnTriggerEnter(Collider other)
    {
        stopTimeTriggerActivated = true;
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
    }
}
