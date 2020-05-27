using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the levelCube with either a press of a numpad key or by changing the variable 
/// rotateToColor to the name of the color
/// 
/// Created by: Jonas
/// </summary>
public class RotatingLevelScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject center;
    public string rotateToColor;
    private MovementScript moveScript;
    private ColorManager colorManagerScript;
    private void Start()
    {
        moveScript = FindObjectOfType<MovementScript>();
        colorManagerScript = FindObjectOfType<ColorManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (moveScript.moving == false)
        {
            RotateLevel();
        }
    }


    /// <summary>
    /// Rotate the level with either numpad or changing rotateToColor
    /// Method by: Jonas
    /// </summary>
    public void RotateLevel()
    {

        if (/*Input.GetKeyDown(KeyCode.Keypad8) || */rotateToColor == "green") 
        {
            moveScript.input = false;
            rotateToColor = "green";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(-90,0,0), Time.deltaTime * 100f);
            if(cube.transform.rotation == Quaternion.Euler(-90, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "yellow")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "teal")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "red")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "purple")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }
            }
        }
        else if (/*Input.GetKeyDown(KeyCode.Keypad6) || */rotateToColor == "purple")
        {
            moveScript.input = false;
            rotateToColor = "purple";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "teal")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "blue")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "green")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "red")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }
            }
        }
        else if (/*Input.GetKeyDown(KeyCode.Keypad4) || */rotateToColor == "yellow")
        {
            moveScript.input = false;
            rotateToColor = "yellow";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, -90))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "red")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "blue")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "green")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "teal")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }

            }
        }
        else if (/*Input.GetKeyDown(KeyCode.Keypad2) || */rotateToColor == "blue")
        {
            moveScript.input = false;
            rotateToColor = "blue";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(90, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(90, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "yellow")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "red")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "teal")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "purple")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }
            }
        }
        else if (/*Input.GetKeyDown(KeyCode.Keypad5) || */rotateToColor == "teal")
        {
            moveScript.input = false;
            rotateToColor = "teal";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "yellow")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if(colorManagerScript.currentLevelColor.ToString()== "blue")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "green")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "purple")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }
            }
        }
        else if (/*Input.GetKeyDown(KeyCode.Keypad0) || */rotateToColor == "red")
        {
            moveScript.input = false;
            rotateToColor = "red";
            cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(180, 180, 0), Time.deltaTime * 100f);
            if (cube.transform.rotation == Quaternion.Euler(180, 180, 0))
            {
                moveScript.input = true;
                rotateToColor = "";

                //Code by: Kristian
                //Checks which color you rotated from, and moves you one rotation onto the new color. 
                if (colorManagerScript.currentLevelColor.ToString() == "purple")
                {
                    moveScript.StartCoroutine("MoveRight");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "blue")
                {
                    moveScript.StartCoroutine("MoveUp");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "green")
                {
                    moveScript.StartCoroutine("MoveDown");
                    moveScript.input = false;
                }
                else if (colorManagerScript.currentLevelColor.ToString() == "yellow")
                {
                    moveScript.StartCoroutine("MoveLeft");
                    moveScript.input = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
        FindObjectOfType<MovementScript>().OnTriggerReset(center);
    }
}
