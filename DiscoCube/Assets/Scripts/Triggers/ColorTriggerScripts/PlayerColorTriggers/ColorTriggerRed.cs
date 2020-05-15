
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to red
/// Created by: Jonas
/// </summary>
public class ColorTriggerRed : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.red;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
