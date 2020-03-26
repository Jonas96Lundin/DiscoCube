
using UnityEngine;

public class ColorTriggerRed : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.red;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
