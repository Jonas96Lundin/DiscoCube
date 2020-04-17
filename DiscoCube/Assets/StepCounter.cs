using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    public static int stepCounter = 0;
    [SerializeField]
    Text stepsCounterText;

    void Update()
    {
        stepsCounterText.text = stepCounter.ToString();
    }
}
