
using UnityEngine;

public class LevelColorTriggerBlue : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.blue;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
