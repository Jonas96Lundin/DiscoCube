
using UnityEngine;

public class ColorTriggerGreen : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.green;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
