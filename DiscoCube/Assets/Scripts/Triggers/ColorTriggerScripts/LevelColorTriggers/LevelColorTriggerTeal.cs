
using UnityEngine;

public class LevelColorTriggerTeal : MonoBehaviour
{

    void OnTriggerEnter(Collider c)
    {
        
        FindObjectOfType<ColorManager>().currentLevelColor = ColorManager.LevelColors.teal;
        FindObjectOfType<ColorManager>().CheckLevelColorCollision();
    }
}
