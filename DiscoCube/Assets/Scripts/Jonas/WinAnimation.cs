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
    //Rasmus kod:
    public GameObject completeLevelUI;
    bool isActivated = false;
    float animationDelay;
    //Slut på Rasmus kod
    [SerializeField]
    ColorManager.LevelColors winColor;


    // Start is called before the first frame update
    public void Start()
    {
        // Declares start and end position for the cube win movement
        startPos = transform.position;
        endPosOrientation = new Vector3(0, -4, 0);
        endPos = transform.position + endPosOrientation;
        //victoryScript = FindObjectOfType<Victory>();
    }

    // Update is called once per frame
    public void Update()
    {
        // TODO: When the Restart function is called, the winning trigger is never activated.
        if (!isWinning && isActivated/*colorManager.currentLevelColor == winColor && colorManager.currentColor.ToString() == colorManager.currentWinningColor.ToString()*/)
        {
            endPos = transform.position + endPosOrientation;
            isWinning = true;
        }
        if (isWinning)
        {
            //victoryScript.Win();
            moveSpeed += 0.01f; //Adjust this for how fast you want it to be.
            transform.position = Vector3.Lerp(transform.position, endPos, moveSpeed);
            //FindObjectOfType<Victory>().GoalTrigger();
            //Rasmus kod:
            animationDelay += 1 * Time.deltaTime;
            if (isActivated && animationDelay >= 1f)
            {
                Win();
            }
            if (isActivated && animationDelay >= 2f)
            {
                animationDelay = 0;
            }
        }

    }
    public void SetOrientation(Vector3 orientation)
    {
        endPosOrientation = orientation;

    }
    // Rasmus kod:
    public void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Goal" && colorManager.currentLevelColor == winColor && colorManager.currentColor.ToString() == colorManager.currentWinningColor.ToString())
        {
            animationDelay = 0;
            //TODO           
            //Lås movement så att man inte kan fortsätta röra på sig efter victory animation har påbörjats. Koordinera med Kristians movement script.
            isActivated = true;

        }
    }

    public void Win()
    {
        completeLevelUI.SetActive(true);

    }
}
