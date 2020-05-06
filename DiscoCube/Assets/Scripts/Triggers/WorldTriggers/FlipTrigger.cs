using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject triggerGameObject, center;

    [SerializeField]
    public string triggerColor1, triggerColor2;
    string savedTriggerColor1, savedTriggerColor2, oldLevelColor;

    bool triggerActivated;

    MovementScript moveScript;
    ColorManager colorScript;
    RotatingLevelScript rotateScript;
    void Start()
    {
        moveScript = FindObjectOfType<MovementScript>();
        colorScript = FindObjectOfType<ColorManager>();
        rotateScript = FindObjectOfType<RotatingLevelScript>();
        savedTriggerColor1 = triggerColor1;
        savedTriggerColor2 = triggerColor2;
        oldLevelColor = colorScript.currentLevelColor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActivated && moveScript.movning == false && colorScript.isOnGround == false)
        {
            FlipDirection();
            
        }

        if(oldLevelColor != colorScript.currentLevelColor.ToString())
        {
            triggerActivated = false;
            oldLevelColor = colorScript.currentLevelColor.ToString();
        }

        

    }

    //TODO
    //Can we make thís more general so that it is not dependent on colors too much?
    void FlipDirection()
    {

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
        triggerActivated = false;
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        triggerColor1 = savedTriggerColor1;
        triggerColor2 = savedTriggerColor2;
        colorScript.isOnGround = false;
        triggerActivated = true;
    }

    public void ResetTriggerColors()
    {
        triggerColor1 = "";
        triggerColor2 = "";
    }

    public void ContinueMovementAfterRotation()
    {
        if (triggerColor1 == "yellow" && triggerColor2 == "teal" && colorScript.currentLevelColor.ToString() == "teal")
        {
            Debug.LogError("How did I get here?");
            moveScript.StartCoroutine("MoveLeft");
            moveScript.input = false;
        }
    }


}
