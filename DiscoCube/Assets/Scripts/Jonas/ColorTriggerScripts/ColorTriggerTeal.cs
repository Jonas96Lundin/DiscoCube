
using UnityEngine;

public class ColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.Colors.teal;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
