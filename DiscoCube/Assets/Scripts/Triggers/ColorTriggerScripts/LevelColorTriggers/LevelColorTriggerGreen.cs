
using UnityEngine;

public class LevelColorTriggerGreen : MonoBehaviour
{

    void OnTriggerEnter()
    {
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.green;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
