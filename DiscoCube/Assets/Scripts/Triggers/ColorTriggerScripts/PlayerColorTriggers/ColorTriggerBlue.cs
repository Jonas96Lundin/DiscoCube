
using UnityEngine;

public class ColorTriggerBlue : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.blue;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
