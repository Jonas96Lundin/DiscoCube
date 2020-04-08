using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour
{
    [SerializeField] Text stepsCounterText;
    int stepCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stepCounter++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stepCounter++;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            stepCounter++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stepCounter++;
        }

        stepsCounterText.text = stepCounter.ToString();
    }
}
