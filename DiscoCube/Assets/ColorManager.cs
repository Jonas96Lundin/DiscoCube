
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public enum Colors { blue, green, purple, yellow, red, teal};
    public Colors currentColor = Colors.red;

    public void CheckColorCollision()
    {
        switch (currentColor)
        {
            case Colors.blue:
                Debug.Log("Blue on the ground");
                break;
            case Colors.green:
                Debug.Log("Green on the ground");
                break;
            case Colors.purple:
                Debug.Log("Purple on the ground");
                break;
            case Colors.yellow:
                Debug.Log("Yellow on the ground");
                break;
            case Colors.red:
                Debug.Log("Red on the ground");
                break;
            case Colors.teal:
                Debug.Log("Teal on the ground");
                break;
        }
    }
}
