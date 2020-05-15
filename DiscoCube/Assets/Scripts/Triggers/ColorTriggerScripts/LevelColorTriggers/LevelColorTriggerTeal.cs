
using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to teal
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {
        
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.teal;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
