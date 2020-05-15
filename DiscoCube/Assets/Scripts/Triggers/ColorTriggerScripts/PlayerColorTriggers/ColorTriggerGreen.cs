
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to green
/// Created by: Jonas
/// </summary>
public class ColorTriggerGreen : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.green;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
