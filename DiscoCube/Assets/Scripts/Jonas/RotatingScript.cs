using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject center;
    public string rotateToColor;
    private Movement_Side_Change moveScript;

    private void Start()
    {
        moveScript = FindObjectOfType<Movement_Side_Change>();
    }
    // Update is called once per frame
    void Update()
    {
        if (moveScript.movning == false)
        {
            RotateWhenPressingButton();
        }
        
    }

    // Use numpad to change rotation to the side with the color "rotation"
    public void RotateWhenPressingButton()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8) || rotateToColor == "green")
        {
            moveScript.input = false;
            rotateToColor = "green";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(-90,0,0), Time.deltaTime * 100f);
            if(cube.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";
                //moveScript.RotateEdgeStep();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || rotateToColor == "purple")
        {
            moveScript.input = false;
            rotateToColor = "purple";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                moveScript.input = true;
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || rotateToColor == "yellow")
        {
            moveScript.input = false;
            rotateToColor = "yellow";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, -90))
            {
                moveScript.input = true;
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || rotateToColor == "blue")
        {
            moveScript.input = false;
            //Debug.Log("Rotating to blue");
            rotateToColor = "blue";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(90, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(90, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || rotateToColor == "teal")
        {
            moveScript.input = false;
            //Debug.Log("Rotating to teal");
            rotateToColor = "teal";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) || rotateToColor == "red")
        {
            moveScript.input = false;
            //Debug.Log("Rotate to red");
            rotateToColor = "red";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(180, 180, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(180, 180, 0))
            {
                moveScript.input = true;
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
    }
}
