
using UnityEngine;

public class LevelColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.teal;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
