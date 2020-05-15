
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to yellow
/// Created by: Jonas
/// </summary>
public class ColorTriggerYellow : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.yellow;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
