using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour
{

    public GameObject triggerGO;
    public GameObject center;
    //Movement_Side_Change msc = GameObject.FindObjectOfType<Movement_Side_Change>();

    private bool activated;
    private bool ready;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && FindObjectOfType<Movement_Side_Change>().movning == false)
        {
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        Debug.Log("I just flipper my center!");
        FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
        activated = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        activated = true;
        Debug.Log("Activation complete!");
    }
}
