
using UnityEngine;

public class ColorTriggerPurple : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.purple;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
