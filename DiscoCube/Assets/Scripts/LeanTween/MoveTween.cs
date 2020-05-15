using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Use LeanTween to move an object
/// Created by: Jonas
/// </summary>
public class MoveTween : MonoBehaviour
{
    public GameObject movableObject;
    [SerializeField]
    LeanTweenType easeType;
    [SerializeField]
    float moveToYPos;
    [SerializeField]
    float timeToReachYPos;
    [SerializeField]
    int loopAmount;

    public void Start()
    {
        if (movableObject.tag == "TutorialArrow")
        {
            MoveY();
        }
    }
    /// <summary>
    /// Moves an object in Y direction with the help of LeanTween.
    /// Method by: Jonas
    /// </summary>
    public void MoveY()
    {
        if (!LeanTween.isTweening(movableObject))
        {
            LeanTween.moveY(movableObject, moveToYPos, timeToReachYPos).setLoopPingPong(loopAmount).setEase(easeType);

        }
    }
}
