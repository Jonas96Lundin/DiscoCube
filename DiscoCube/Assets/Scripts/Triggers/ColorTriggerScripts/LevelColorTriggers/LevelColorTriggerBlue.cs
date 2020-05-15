using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to blue
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerBlue : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.blue;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
