using UnityEngine;

/// <summary>
/// Holds the current color for the playercube and the levelcube. Also holds the winningcolor.
/// Created by: Jonas
/// </summary>
public class ColorManager : MonoBehaviour
{
    public CubeColors oldColor;
    public enum CubeColors { blue, green, purple, yellow, red, teal };
    public CubeColors currentColor;

    public enum LevelColors { blue, green, purple, yellow, red, teal };
    public LevelColors currentLevelColor;

    public enum WinningColors { blue, green, purple, yellow, red, teal };
    public WinningColors currentWinningColor;

    enum GlowingColorChoice { allColorsGlow, winningColorGlow, noColorGlow};
    [SerializeField]
    GlowingColorChoice currentGlowingColorChoice;

    public bool isOnGround;

    //public void CheckColorCollision()
    //{
    //    switch (currentColor)
    //    {
    //        case CubeColors.blue:
    //            Debug.Log("Blue on the ground");
    //            break;
    //        case CubeColors.green:
    //            Debug.Log("Green on the ground");
    //            break;
    //        case CubeColors.purple:
    //            Debug.Log("Purple on the ground");
    //            break;
    //        case CubeColors.yellow:
    //            Debug.Log("Yellow on the ground");
    //            break;
    //        case CubeColors.red:
    //            Debug.Log("Red on the ground");
    //            break;
    //        case CubeColors.teal:
    //            Debug.Log("Teal on the ground");
    //            break;
    //    }
    //}

        /// <summary>
        /// Sets the currentWinningColor acording to what the currentLevelColor is.
        /// Method by: Jonas
        /// </summary>
    public void CheckLevelColorCollision()
    {
        switch (currentLevelColor)
        {
            case LevelColors.blue:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be green");
                currentWinningColor = WinningColors.green;
                isOnGround = true;
                break;
            case LevelColors.green:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be blue");
                currentWinningColor = WinningColors.blue;
                isOnGround = true;
                break;
            case LevelColors.purple:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be yellow");
                currentWinningColor = WinningColors.yellow;
                isOnGround = true;
                break;
            case LevelColors.yellow:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be purple");
                currentWinningColor = WinningColors.purple;
                isOnGround = true;
                break;
            case LevelColors.red:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be teal");
                currentWinningColor = WinningColors.teal;
                isOnGround = true;
                break;
            case LevelColors.teal:
                //Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be red");
                currentWinningColor = WinningColors.red;
                isOnGround = true;
                break;
        }
    }
    /// <summary>
    /// Get the currentColor for the playercube
    /// </summary>
    /// <returns></returns>
    public CubeColors GetCurrentColor()
    {
        return currentColor;
    }

    /// <summary>
    /// Sets the levelcube materials to glowing
    /// Method by: Jonas
    /// </summary>
    /// <param name="color"></param>
    public void SetGlowingColors(LevelColors color)
    {
        GameObject[] cubePlane = GameObject.FindGameObjectsWithTag("ColorPlane");
        switch (currentGlowingColorChoice)
        {
            case GlowingColorChoice.noColorGlow:
                break;
            case GlowingColorChoice.winningColorGlow:
                foreach (GameObject go in cubePlane)
                {
                    if (color.ToString() == "teal")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("TealGlow", typeof(Material)) as Material;
                    }
                    else if (color.ToString() == "red")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("RedGlow", typeof(Material)) as Material;
                    }
                    else if (color.ToString() == "blue")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("BlueGlow", typeof(Material)) as Material;
                    }
                    else if (color.ToString() == "green")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("GreenGlow", typeof(Material)) as Material;
                    }
                    else if (color.ToString() == "yellow")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("YellowGlow", typeof(Material)) as Material;
                    }
                    else if (color.ToString() == "purple")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("PurpleGlow", typeof(Material)) as Material;
                    }
                }
                break;
            case GlowingColorChoice.allColorsGlow:
                foreach (GameObject go in cubePlane)
                {
                    if (go.name == "Teal Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("TealGlow", typeof(Material)) as Material;
                    }
                    else if (go.name == "Red Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("RedGlow", typeof(Material)) as Material;
                    }
                    else if (go.name == "Blue Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("BlueGlow", typeof(Material)) as Material;
                    }
                    else if (go.name == "Green Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("GreenGlow", typeof(Material)) as Material;
                    }
                    else if (go.name == "Yellow Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("YellowGlow", typeof(Material)) as Material;
                    }
                    else if (go.name == "Purple Plane")
                    {
                        go.GetComponent<Renderer>().sharedMaterial = Resources.Load("PurpleGlow", typeof(Material)) as Material;
                    }
                }
                break;
        }
        
        
    }
}
