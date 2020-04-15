using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    [SerializeField] Text stepsCounterText;
    public static int stepCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stepsCounterText.text = stepCounter.ToString();
    }
}
