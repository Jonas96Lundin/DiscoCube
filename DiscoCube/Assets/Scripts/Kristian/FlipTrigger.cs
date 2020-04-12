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
    //Movement_Side_Change msc = GameObject.FindObjectOfType<Movement_Side_Change>();

    private bool activated;
    private bool ready;
    void Start()
    {
        savedTriggerColor1 = triggerColor1;
        savedTriggerColor2 = triggerColor2;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(oldTriggerColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString());
        //Debug.Log("oldTriggerColor = " + oldTriggerColor);
        if (activated && FindObjectOfType<Movement_Side_Change>().movning == false && /*oldTriggerColor == FindObjectOfType<ColorManager>().currentLevelColor.ToString() &&*/ FindObjectOfType<ColorManager>().isOnGround == false)
        {
            //oldTriggerColor = FindObjectOfType<ColorManager>().currentLevelColor.ToString();
            //Debug.Log(" UPDATE oldTriggerColor = " + oldTriggerColor);
            FlipDirection();
        }
        //if(FindObjectOfType<ColorManager>().isOnGround == true)
        //{
        //    oldLevelColor = FindObjectOfType<ColorManager>().currentLevelColor.ToString();
        //}
        if(oldLevelColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString())
        {
            activated = false;
            oldLevelColor = FindObjectOfType<ColorManager>().currentLevelColor.ToString();
        }
    }

    void FlipDirection()
    {
        Debug.Log("triggerColor1 = " + triggerColor1);
        Debug.Log("triggerColor2 = " + triggerColor2);
        Debug.Log("THIS particular script is on " + gameObject.name);
        if (FindObjectOfType<ColorManager>().currentLevelColor.ToString() == triggerColor1)
        {
            //activated = false;
            FindObjectOfType<RotatingScript>().rotateToColor = triggerColor2;
            FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
            //Debug.Log("I just flipped to " + triggerColor2);
            
        }
        else if(FindObjectOfType<ColorManager>().currentLevelColor.ToString() == triggerColor2)
        {
            //activated = false;
            FindObjectOfType<RotatingScript>().rotateToColor = triggerColor1;
            FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
            //Debug.Log("I just flipped to " + triggerColor1);
        }
        //Debug.Log("I just flipper my center!");
        activated = false;
        //ResetTriggerColors();
    }
    
    void OnTriggerEnter(Collider other)
    {
        triggerColor1 = savedTriggerColor1;
        triggerColor2 = savedTriggerColor2;
        FindObjectOfType<ColorManager>().isOnGround = false;
        activated = true;
        //Debug.Log("Activated!");
        //if(FindObjectOfType<Movement_Side_Change>().movning==false && oldTriggerColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString())
        //{
        //    Debug.Log("Unactivated!"); 
        //    activated = false;
        //}
    }

    public void ResetTriggerColors()
    {
        triggerColor1 = "";
        triggerColor2 = "";
    }
}
