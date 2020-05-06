
using UnityEngine;

public class ColorTriggerYellow : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.yellow;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
