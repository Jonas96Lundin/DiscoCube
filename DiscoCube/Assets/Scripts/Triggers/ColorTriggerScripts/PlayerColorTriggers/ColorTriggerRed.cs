
using UnityEngine;

public class ColorTriggerRed : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.red;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
