using UnityEngine;

public class UITweenSpriteAnimator : MonoBehaviour
{
    public RectTransform rectTransform;
    public Sprite[] sprites;
    public float timer;

    void Update()
    {
        //TODO
        //Find out why there is such a big delay on startup.
        LeanTween.play(gameObject.GetComponent<RectTransform>(), sprites).setLoopPingPong();
    }
}
