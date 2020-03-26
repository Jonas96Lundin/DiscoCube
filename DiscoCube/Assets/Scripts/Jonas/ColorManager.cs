
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum CubeColors { blue, green, purple, yellow, red, teal};
    public CubeColors currentColor = CubeColors.red;

    public enum LevelColors { blue, green, purple, yellow, red, teal };
    public LevelColors currentLevelColor = LevelColors.red;

    public void CheckColorCollision()
    {
        switch (currentColor)
        {
            case CubeColors.blue:
                Debug.Log("Blue on the ground");
                break;
            case CubeColors.green:
                Debug.Log("Green on the ground");
                break;
            case CubeColors.purple:
                Debug.Log("Purple on the ground");
                break;
            case CubeColors.yellow:
                Debug.Log("Yellow on the ground");
                break;
            case CubeColors.red:
                Debug.Log("Red on the ground");
                break;
            case CubeColors.teal:
                Debug.Log("Teal on the ground");
                break;
        }
    }
    public void CheckLevelColorCollision()
    {
        switch (currentLevelColor)
        {
            case LevelColors.blue:
                Debug.Log("You stepped on" + currentLevelColor.ToString() + "Cube top color should be green");
                break;
            case LevelColors.green:
                Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be blue");
                break;
            case LevelColors.purple:
                Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be yellow");
                break;
            case LevelColors.yellow:
                Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be purple");
                break;
            case LevelColors.red:
                Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be teal");
                break;
            case LevelColors.teal:
                Debug.Log("You stepped on " + currentLevelColor.ToString() + ". Cube top color should be red");
                break;
        }
    }
}
