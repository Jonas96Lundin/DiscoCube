
using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to green
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerGreen : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.green;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
