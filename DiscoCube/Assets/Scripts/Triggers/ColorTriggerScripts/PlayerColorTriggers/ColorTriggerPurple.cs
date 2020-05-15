
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to purple
/// Created by: Jonas
/// </summary>
public class ColorTriggerPurple : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.purple;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
