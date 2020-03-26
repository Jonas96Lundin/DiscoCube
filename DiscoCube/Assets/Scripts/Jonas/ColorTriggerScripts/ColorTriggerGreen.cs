
using UnityEngine;

public class ColorTriggerGreen : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.green;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
