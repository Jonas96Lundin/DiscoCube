﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    //Owner: Raimon 

    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    public void FadeToFast(string scene)
    {
        StartCoroutine(Restart(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime * 2f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            //img.color = new Color(100f, 0f, 255f, a); //Not working
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        
        SceneManager.LoadScene(scene);
    }

    IEnumerator Restart(string scene)
    {

        float t = 0f;

        while (t < 0.5f)
        {
            t += Time.deltaTime * 1f;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
