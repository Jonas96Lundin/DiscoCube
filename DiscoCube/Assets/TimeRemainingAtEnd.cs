using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemainingAtEnd : MonoBehaviour
{
    [SerializeField]
    Text timerText;
    [SerializeField]
    CountdownTimer timeCounter;

    private float waitTime = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        timerText.text = "0 seconds left!";
        float time = 0f;
        yield return new WaitForSeconds(0.5f);
        while (time <= timeCounter.Timer)
        {
            time += 0.1f;
            timerText.text = time.ToString("0.0") + " seconds left!";
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
