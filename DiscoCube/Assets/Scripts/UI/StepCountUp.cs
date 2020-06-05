using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCountUp : MonoBehaviour
{
    //Creator Raimon

    [SerializeField]
    Text stepsText;
    [SerializeField]
    StepCounter stepCounter;

    private float waitTime = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        stepsText.text = "Steps taken: 0";
        int steps = 0;

        yield return new WaitForSeconds(0.7f);
        while (steps < stepCounter.stepCounter)
        {
            steps++;
            stepsText.text = "Steps taken: " + steps.ToString();
            waitTime -= 0.05f;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
