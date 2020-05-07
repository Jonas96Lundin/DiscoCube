using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void MoveY()
    {
        if (!LeanTween.isTweening(movableObject))
        {
            LeanTween.moveY(movableObject, moveToYPos, timeToReachYPos).setLoopPingPong(loopAmount).setEase(easeType);

        }
    }
}
