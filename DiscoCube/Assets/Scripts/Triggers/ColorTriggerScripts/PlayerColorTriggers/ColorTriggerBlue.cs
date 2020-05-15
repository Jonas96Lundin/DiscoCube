
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to blue
/// Created by: Jonas
/// </summary>
public class ColorTriggerBlue : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.blue;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
