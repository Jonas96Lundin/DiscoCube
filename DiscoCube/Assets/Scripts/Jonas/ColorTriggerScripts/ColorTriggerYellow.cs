
using UnityEngine;

public class ColorTriggerYellow : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.yellow;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
