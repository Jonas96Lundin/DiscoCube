using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
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

    void Update()
    {
        inputDelay++;
        //TODO: May have to change the delaytimer, so the movement feels more responsive.
        if(input == true && inputDelay >= 60)
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

    }

    IEnumerator MoveUp()
    {
        for (int i = 0; i < 90 / step; i++)
        {
            player.transform.RotateAround(up.transform.position, Vector3.right, step);
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
            player.transform.RotateAround(down.transform.position, Vector3.left, step);
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
            player.transform.RotateAround(right.transform.position, Vector3.back, step);
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
            player.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        inputDelay = 0f;
        input = true;
    }


}
