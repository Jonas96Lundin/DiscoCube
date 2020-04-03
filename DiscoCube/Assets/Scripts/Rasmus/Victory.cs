using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject goal;
    bool activated = false;
    float animationDelay;
    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Goal" )
        {
            activated = true;
            //animationDelay = 0;
        }
    }

    private void Update()
    {
        Debug.Log(animationDelay);
        animationDelay += Time.deltaTime;

    }
    public void GoalTrigger()
    {
       
        
        if (activated && animationDelay >= 2f)
        {
            Debug.Log("Hallååå");
            Win();
        }
    }

    public GameObject completeLevelUI;
   
   
    public void Win()
    {
        completeLevelUI.SetActive(true);

    }

}
