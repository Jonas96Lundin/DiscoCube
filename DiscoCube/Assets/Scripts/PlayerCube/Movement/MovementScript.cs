using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //Layermask to check for obstacles
    [SerializeField]
    LayerMask obstacleLayer;

    private Vector3 offset;
    
    public GameObject player;

    public WinTrigger winAnimation; // For the winning animation. /Jonas
    //public GameObject rightEdge;
    enum Direction { right, left, up, down};

    PauseMenu pauseMenu;
    StepCounter stepCounterScript;
    
    public GameObject center;
    public GameObject right;
    public GameObject left;
    public GameObject up;
    public GameObject down;

    public int step = 9;

    public string inputVertical, inputHorizontal; //Gives the ability to change the controller with the ControllerSetup script /Kristian.

    public float speed = 0.01f;
    public float inputDelay = 5f;

    public bool input = true;
    public bool movning = false;
    private Vector3 rotateUp = new Vector3(1, 0, 0), rotateDown = new Vector3(-1, 0, 0), rotateRight = new Vector3(0, 0, -1), rotateLeft = new Vector3(0, 0, 1);

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        stepCounterScript = FindObjectOfType<StepCounter>();
        inputVertical = "Vertical";
        inputHorizontal = "Horizontal";
    }

    void Update()
    {
        inputDelay += Time.deltaTime;
        //TODO: May have to change the delaytimer, so the movement feels more responsive.

        //Stops movement if game is paused or freelook is activated
        if (pauseMenu.gameIsPaused || CameraController.freelookActivated)
        {
            return;
        }

        //Movement
        if (input == true && inputDelay >= 0.25)
        {
            //TODO: Maybe find a way so that Up is not allways dominant when multiple keys are pressed down at the same time.
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0 || Input.GetAxis(inputVertical) > 0)
            {
                if (CheckForObstacles(this.transform, Vector3.forward))
                {
                    return;
                }
                
                StartCoroutine("MoveUp");
                input = false;
                stepCounterScript.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0 || Input.GetAxis(inputVertical) < 0)
            {
                if (CheckForObstacles(this.transform, Vector3.back))
                {
                    return;
                }
                
                StartCoroutine("MoveDown");
                input = false;
                stepCounterScript.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetAxis(inputHorizontal) > 0)
            {
                if (CheckForObstacles(this.transform, Vector3.right))
                {
                    return;
                }
                StartCoroutine("MoveRight");
                input = false;
                stepCounterScript.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetAxis(inputHorizontal) < 0)
            {
                if (CheckForObstacles(this.transform, Vector3.left))
                {
                    return;
                }
                StartCoroutine("MoveLeft");
                input = false;
                stepCounterScript.stepCounter++;
            }

            // If the cube is moving, play the sound. /Jonas
            if (!input)
            {
                FindObjectOfType<AudioManager>().Play("ChestDrawer");
            }

            if(inputDelay >= 100)
            {
                inputDelay = 0f;
            }
        }
    }


    /// <summary>
    /// CheckForObstacles
    /// Checks for any obstacles with the layer "ObstacleLayer" 4 units in the given direction
    /// </summary>
    /// <param name="transform">The object you want to check from</param>
    /// <param name="direction">The direction you want to check for obstacles in</param>
    /// <returns>return a bool true/false if anything is found</returns>
    bool CheckForObstacles(Transform transform, Vector3 direction)
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, direction, out hit, 4f, obstacleLayer);
    }

    IEnumerator MoveUp()
    {
        movning = true;
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(up.transform.position, rotateUp, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
        movning = false;

    }

    IEnumerator MoveDown()
    {
        movning = true;
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(down.transform.position, rotateDown, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
        movning = false;
    }

    IEnumerator MoveRight()
    {
        movning = true;
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(right.transform.position, rotateRight, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
        movning = false;
    }

    IEnumerator MoveLeft()
    {
        movning = true;
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(left.transform.position, rotateLeft, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
        movning = false;
    }

    //TEST: A trigger that changes the Vector3 values of the different directions.
    //Reset all values on Empty Objects
    public void OnTriggerReset(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, 0, -1);
        rotateLeft = new Vector3(0, 0, 1);

        winAnimation.SetOrientation(new Vector3(0, -4, 0)); // Jonas test
    }
    

}
