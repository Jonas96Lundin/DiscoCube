
using UnityEngine;
/// <summary>
/// Sets the currentLevelColor in ColorManager to purple
/// Created by: Jonas
/// </summary>
public class LevelColorTriggerPurple : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.purple;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
