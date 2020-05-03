using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    //Owner: David
    //Code from Raimon

    public int stepCounter = 0;
    [SerializeField]
    Text stepsCounterText;

    void start()
    {
        stepsCounterText.text = "0";
    }

    void Update()
    {
        stepsCounterText.text = stepCounter.ToString();
    }
}
