using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class WinAnimation : MonoBehaviour
{
    Vector3 endPos;
    Vector3 startPos;
    Vector3 endPosOrientation;
    float moveSpeed;
    public bool isWinning = false;
    public ColorManager colorManager;
    public GameObject goal;
    Victory victoryScript;
    [SerializeField]
    ColorManager.LevelColors winColor;


    // Start is called before the first frame update
    public void Start()
    {
        // Declares start and end position for the cube win movement
        startPos = transform.position;
        endPosOrientation = new Vector3(0, -4, 0);
        endPos = transform.position + endPosOrientation;
        victoryScript = FindObjectOfType<Victory>();
        victoryScript.Win();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!isWinning && colorManager.currentLevelColor == winColor && colorManager.currentColor.ToString() == colorManager.currentWinningColor.ToString())
        {
            endPos = transform.position + endPosOrientation;
            isWinning = true;
        }
        if (isWinning)
        {
            victoryScript.Win();
            moveSpeed += 0.01f; //Adjust this for how fast you want it to be.
            transform.position = Vector3.Lerp(transform.position, endPos, moveSpeed);
            //FindObjectOfType<Victory>().GoalTrigger();
        }
    }
    public void SetOrientation(Vector3 orientation)
    {
        endPosOrientation = orientation;

    }
}
