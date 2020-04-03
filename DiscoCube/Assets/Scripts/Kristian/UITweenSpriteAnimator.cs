using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITweenSpriteAnimator : MonoBehaviour
{
    public RectTransform rectTransform;

    float localScale;
    public Sprite[] sprites;
    public float timer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LeanTween.play(gameObject.GetComponent<RectTransform>(), sprites).setLoopPingPong();
    }
}
