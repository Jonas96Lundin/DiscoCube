
using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to yellow
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerYellow : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.yellow;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
