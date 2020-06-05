using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FinishTime : MonoBehaviour
{
    //Creator Raimon
    [SerializeField]
    Text timerText;
    [SerializeField]
    CountUpTimer timeCounter;

    private float waitTime = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        timerText.text = "in: 0 seconds!";
        float time = 0f;
        yield return new WaitForSeconds(0.5f);
        while (time <= timeCounter.Timer)
        {
            time += 0.1f;
            timerText.text = "in: " + time.ToString("0.0") + " seconds!";
            if (time <= 2)
            {
                waitTime -= 0.05f;
            }
            else
            {
                waitTime -= 0.03f;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
