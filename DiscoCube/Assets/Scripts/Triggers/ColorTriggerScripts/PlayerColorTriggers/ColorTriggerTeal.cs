
using UnityEngine;

public class ColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.teal;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
