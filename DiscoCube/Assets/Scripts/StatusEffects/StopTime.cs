using UnityEngine;

public class StopTime : MonoBehaviour
{
    private bool stopTimeTriggerActivated;
    CountdownTimer countDownTimer;
    float stopTimeCounter = 0;

    void Start()
    {
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
    }
}
