using UnityEngine;

/// <summary>
/// This script takes in an array of sprites and loops between them at a fixed rate. 
/// This is used in some UI elements such as the Timer text, that "flashes" in different colors.
/// 
/// Owner: Kristian
/// </summary>

public class UITweenSpriteAnimator : MonoBehaviour
{
    public RectTransform rectTransform;
    public Sprite[] sprites;

    private void Start()
    {
        LeanTween.play(rectTransform, sprites).setLoopPingPong(-1);
    }

}
