using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Side_change : MonoBehaviour
{
    private Vector3 offset;

    public GameObject player;

    public GameObject center;
    public GameObject right;
    public GameObject left;
    public GameObject up;
    public GameObject down;

    public int step = 9;

    public float speed = 0.01f;
    public float inputDelay = 5f;

    bool input = true;

    private Vector3 rotateUp = new Vector3(1, 0, 0), rotateDown = new Vector3(-1, 0, 0), rotateRight = new Vector3(0, 0 - 1), rotateLeft = new Vector3(0, 0, 1);

    void Update()
    {
        inputDelay++;
        //TODO: May have to change the delaytimer, so the movement feels more responsive.
        if (input == true && inputDelay >= 60)
        {
            //TODO: Maybe find a way so that Up is not allways dominant when multiple keys are pressed down at the same time.
            if (Input.GetKey(KeyCode.UpArrow))
            {
                StartCoroutine("MoveUp");
                input = false;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                StartCoroutine("MoveDown");
                input = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                StartCoroutine("MoveRight");
                input = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                StartCoroutine("MoveLeft");
                input = false;
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
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(up.transform.position, rotateUp, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
    }

    IEnumerator MoveDown()
    {
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(down.transform.position, rotateDown, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
    }

    IEnumerator MoveRight()
    {
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(right.transform.position, rotateRight, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
    }

    IEnumerator MoveLeft()
    {
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(left.transform.position, rotateLeft, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
    }


    //TEST: A trigger that changes the Vector3 values of the different directions.
    public void OnTriggerFlipUp(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(90, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, 1, 0);
        rotateLeft = new Vector3(0, -1, 0);
    }

    public void OnTriggerFlipDown(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(-90, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, -1, 0);
        rotateLeft = new Vector3(0, 1, 0);
    }

    public void OnTriggerFlipRight(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, -90);
        rotateUp = new Vector3(0, -1, 0);
        rotateDown = new Vector3(0, 1, 0);
        rotateRight = new Vector3(0, 0 - 1);
        rotateLeft = new Vector3(0, 0, 1);
    }

    public void OnTriggerFlipLeft(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, 90);
        rotateUp = new Vector3(0, 1, 0);
        rotateDown = new Vector3(0, -1, 0);
        rotateRight = new Vector3(0, 0 - 1);
        rotateLeft = new Vector3(0, 0, 1);
    }

    //Reset all values on Empty Objects
    public void OnTriggerReset(GameObject center)
    {
        center.transform.rotation = Quaternion.Euler(0, 0, 0);
        rotateUp = new Vector3(1, 0, 0);
        rotateDown = new Vector3(-1, 0, 0);
        rotateRight = new Vector3(0, 0 - 1);
        rotateLeft = new Vector3(0, 0, 1);
    }
}
