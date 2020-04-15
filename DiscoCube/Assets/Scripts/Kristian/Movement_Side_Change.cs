using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Side_Change : MonoBehaviour
{
    private Vector3 offset;
    
    public GameObject player;

    public WinAnimation winAnimation; // For the winning animation. /Jonas
    //public GameObject rightEdge;
    enum Direction { right, left, up, down};
    Direction currentDirection = Direction.up;

    public GameObject center;
    public GameObject right;
    public GameObject left;
    public GameObject up;
    public GameObject down;

    public int step = 9;

    public float speed = 0.01f;
    public float inputDelay = 5f;

    public bool input = true;
    public bool movning = false;
    private Vector3 rotateUp = new Vector3(1, 0, 0), rotateDown = new Vector3(-1, 0, 0), rotateRight = new Vector3(0, 0, -1), rotateLeft = new Vector3(0, 0, 1);

    void Update()
    {
        inputDelay += Time.deltaTime;
        //TODO: May have to change the delaytimer, so the movement feels more responsive.
        if (input == true && inputDelay >= 0.25)
        {
            //TODO: Maybe find a way so that Up is not allways dominant when multiple keys are pressed down at the same time.
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
            {
                StartCoroutine("MoveUp");
                input = false;
                StepCounter.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0) 
            {
                StartCoroutine("MoveDown");
                input = false;
                StepCounter.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                StartCoroutine("MoveRight");
                input = false;
                StepCounter.stepCounter++;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
            {
                StartCoroutine("MoveLeft");
                input = false;
                StepCounter.stepCounter++;
            }

            // If the cube is moving, play the sound. /Jonas
            if (!input)
            {
                FindObjectOfType<AudioManager>().Play("ChestDrawer");
            }
        }


        //Changes the different directions the cube will rotate depending on orientation.
        //TODO: Make these changes with a trigger in game.
        if (Input.GetKey(KeyCode.S))
        {
            OnTriggerFlipDown(center);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            OnTriggerFlipRight(center);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            OnTriggerFlipLeft(center);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            OnTriggerFlipUp(center);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            OnTriggerReset(center);
        }

    }

    IEnumerator MoveUp()
    {
        movning = true;
        Debug.Log(movning);
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
        Debug.Log("moving = "+movning);
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(left.transform.position, rotateLeft, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
        movning = false;
        Debug.Log("moving = "+movning);
    }


    //TEST: A trigger that changes the Vector3 values of the different directions.
    public void OnTriggerFlipUp(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(90, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, 1, 0);
        rotateLeft = new Vector3(0, -1, 0);

        winAnimation.SetOrientation(new Vector3(0, 0, -4)); // Jonas test
    }

    public void OnTriggerFlipDown(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(-90, 0, 0);
        //center.transform.position = new Vector3(0, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, -1, 0);
        rotateLeft = new Vector3(0, 1, 0);

        winAnimation.SetOrientation(new Vector3(0, 0, 4)); // Jonas test
    }

    public void OnTriggerFlipRight(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, -90);
        rotateUp = new Vector3(0, -1, 0);
        rotateDown = new Vector3(0, 1, 0);
        rotateRight = new Vector3(0, 0, -1);
        rotateLeft = new Vector3(0, 0, 1);

        winAnimation.SetOrientation(new Vector3(-4, 0, 0)); // Jonas test
    }

    public void OnTriggerFlipLeft(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, 90);
        rotateUp = new Vector3(0, 1, 0);
        rotateDown = new Vector3(0, -1, 0);
        rotateRight = new Vector3(0, 0, -1);
        rotateLeft = new Vector3(0, 0, 1);

        winAnimation.SetOrientation(new Vector3(4, 0, 0)); // Jonas test
    }

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
    // Takes one extra step after rotation so that it looks more like one animation.
    public void RotateEdgeStep()
    {
        if (currentDirection == Direction.up)
        {
            StartCoroutine("MoveUp");
            input = false;
        }
        else if (currentDirection == Direction.down)
        {
            StartCoroutine("MoveDown");
            input = false;
        }
        else if (currentDirection == Direction.right)
        {
            StartCoroutine("MoveRight");
            input = false;
        }
        else if (currentDirection == Direction.left)
        {
            StartCoroutine("MoveLeft");
            input = false;
        }
    }
}
