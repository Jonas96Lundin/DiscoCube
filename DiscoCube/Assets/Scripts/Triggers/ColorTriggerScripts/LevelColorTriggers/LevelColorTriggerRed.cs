
using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to red
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerRed : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.red;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
