using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject center;
    public string rotateToColor;

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Movement_Side_Change>().movning == false)
        {
            RotateWhenPressingButton();
        }
        
    }

    // Use numpad to change rotation to the side with the color "rotation"
    public void RotateWhenPressingButton()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8) || rotateToColor == "green")
        {
            //Debug.Log("Rotating to green");
            rotateToColor = "green";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(-90,0,0), Time.deltaTime * 100f);
            if(cube.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                Debug.Log("rotation reseted");
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || rotateToColor == "purple")
        {
            //Debug.Log("Rotating to purple");
            rotateToColor = "purple";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || rotateToColor == "yellow")
        {
            //Debug.Log("Rotating to yellow");
            rotateToColor = "yellow";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, -90))
            {
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || rotateToColor == "blue")
        {
            //Debug.Log("Rotating to blue");
            rotateToColor = "blue";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(90, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(90, 0, 0))
            {
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || rotateToColor == "teal")
        {
            //Debug.Log("Rotating to teal");
            rotateToColor = "teal";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0) || rotateToColor == "red")
        {
            //Debug.Log("Rotate to red");
            rotateToColor = "red";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(180, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(180, 0, 0))
            {
                rotateToColor = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        FindObjectOfType<Movement_Side_Change>().OnTriggerReset(center);
    }
}
