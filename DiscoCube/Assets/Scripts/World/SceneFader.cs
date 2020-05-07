using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    //Owner: Raimon 
    [SerializeField]
    Image img;
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    string musicStop, musicStart;

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

        if (musicStop != null || musicStart != null)
        {
            AudioManager.instance.Stop(musicStop);
            SceneManager.LoadScene(scene);
            AudioManager.instance.Play(musicStart);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
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
