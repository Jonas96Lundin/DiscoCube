using UnityEngine;

public class UITweenSpriteAnimator : MonoBehaviour
{
    public RectTransform rectTransform;
    public Sprite[] sprites;
    public int timer;

    private void Start()
    {
        LeanTween.play(rectTransform, sprites).setLoopPingPong(-1);
    }

}
