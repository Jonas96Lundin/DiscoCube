using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour
{

    public GameObject triggerGO;
    public GameObject center;
    [SerializeField]
    string triggerColor1;
    [SerializeField]
    string triggerColor2;
    string savedTriggerColor1, savedTriggerColor2;
    string oldLevelColor = "teal";

    private bool activated;
    private bool ready;

    private Movement_Side_Change moveScript;
    private ColorManager colorScript;
    private RotatingScript rotateScript;
    void Start()
    {
        savedTriggerColor1 = triggerColor1;
        savedTriggerColor2 = triggerColor2;
        moveScript = FindObjectOfType<Movement_Side_Change>();
        colorScript = FindObjectOfType<ColorManager>();
        rotateScript = FindObjectOfType<RotatingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && moveScript.movning == false && colorScript.isOnGround == false)
        {
            FlipDirection();
        }

        if(oldLevelColor != colorScript.currentLevelColor.ToString())
        {
            activated = false;
            oldLevelColor = colorScript.currentLevelColor.ToString();
        }
    }

    void FlipDirection()
    {
        Debug.Log("triggerColor1 = " + triggerColor1);
        Debug.Log("triggerColor2 = " + triggerColor2);
        Debug.Log("THIS particular script is on " + gameObject.name);

        if (colorScript.currentLevelColor.ToString() == triggerColor1)
        {
            rotateScript.rotateToColor = triggerColor2;
            moveScript.OnTriggerReset(center);   
        }
        else if(colorScript.currentLevelColor.ToString() == triggerColor2)
        {
            rotateScript.rotateToColor = triggerColor1;
            moveScript.OnTriggerReset(center);
        }
        activated = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        triggerColor1 = savedTriggerColor1;
        triggerColor2 = savedTriggerColor2;
        colorScript.isOnGround = false;
        activated = true;
    }

    public void ResetTriggerColors()
    {
        triggerColor1 = "";
        triggerColor2 = "";
    }
}
