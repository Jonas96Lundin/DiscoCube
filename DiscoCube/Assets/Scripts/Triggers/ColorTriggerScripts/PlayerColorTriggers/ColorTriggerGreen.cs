
using UnityEngine;

public class ColorTriggerGreen : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Jag ska vara först");
        Debug.Log(c.name);
        FindObjectOfType<ColorManager>().currentColor = ColorManager.CubeColors.green;
        //FindObjectOfType<ColorManager>().CheckColorCollision();
    }
}
