
using UnityEngine;

public class ColorTriggerPurple : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.purple;
        FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
