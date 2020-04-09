using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour
{

    public GameObject triggerGO;
    public GameObject center;
    public string triggerColor1;
    public string triggerColor2;
    string oldTriggerColor = "teal";
    //Movement_Side_Change msc = GameObject.FindObjectOfType<Movement_Side_Change>();

    private bool activated;
    private bool ready;
    void Start()
    {
        
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
        //if(oldTriggerColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString())
        //{
        //    oldTriggerColor = FindObjectOfType<ColorManager>().currentLevelColor.ToString();
        //}
    }

    void FlipDirection()
    {
        if(FindObjectOfType<ColorManager>().currentLevelColor.ToString() == triggerColor1)
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
        //activated = false;

    }
    
    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<ColorManager>().isOnGround = false;
        activated = true;
        //Debug.Log("Activated!");
        //if(FindObjectOfType<Movement_Side_Change>().movning==false && oldTriggerColor != FindObjectOfType<ColorManager>().currentLevelColor.ToString())
        //{
        //    Debug.Log("Unactivated!"); 
        //    activated = false;
        //}
    }

    
}
