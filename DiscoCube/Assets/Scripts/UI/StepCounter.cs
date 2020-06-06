using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    //Creator: David
    //Contribution by: Raimon

    [HideInInspector]
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
