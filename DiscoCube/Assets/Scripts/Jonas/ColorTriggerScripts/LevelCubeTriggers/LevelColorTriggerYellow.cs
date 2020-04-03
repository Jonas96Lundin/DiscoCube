
using UnityEngine;

public class LevelColorTriggerYellow : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.yellow;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
