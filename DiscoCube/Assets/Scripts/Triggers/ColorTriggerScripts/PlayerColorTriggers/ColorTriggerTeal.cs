
using UnityEngine;
/// <summary>
/// Sets the currentColor, the color that is on the ground, for the playercube in ColorManager to teal
/// Created by: Jonas
/// </summary>
public class ColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.teal;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
