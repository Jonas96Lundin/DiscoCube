
using UnityEngine;

public class LevelColorTriggerRed : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.red;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
