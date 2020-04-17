using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject completeLevelUI;
    bool isActivated = false; 
    float animationDelay;
    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Goal" )
        {
            animationDelay = 0;
            //TODO           
            //Lås movement så att man inte kan fortsätta röra på sig efter victory animation har påbörjats. Koordinera med Kristians movement script.
            isActivated = true;
            
        }
    }
    
    public void Update()
    {
        animationDelay += 1 * Time.deltaTime;
        Debug.Log(animationDelay);
        if (isActivated && animationDelay >= 1f)
        {
            Win();
        }
        if(isActivated && animationDelay >= 2f)
        {
            animationDelay = 0;
        }

    }
    public void Win()
    {
        completeLevelUI.SetActive(true);

    }
}
