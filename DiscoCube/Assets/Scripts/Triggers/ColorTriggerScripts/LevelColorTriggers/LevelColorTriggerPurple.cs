
using UnityEngine;

public class LevelColorTriggerPurple : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.purple;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
