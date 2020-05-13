
using UnityEngine;

public class ColorTriggerGreen : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.green;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
