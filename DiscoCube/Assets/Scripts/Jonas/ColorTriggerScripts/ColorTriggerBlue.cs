
using UnityEngine;

public class ColorTriggerBlue : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.blue;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
