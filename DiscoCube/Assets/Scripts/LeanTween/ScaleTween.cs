using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Scales an object with the help of LeanTween.
/// Created by: Jonas
/// </summary>
public class ScaleTween : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;
    [SerializeField]
    float delay;
    private void Start()
    {
        foreach (GameObject go in objects)
        {
            if (go.tag == "TutorialDialogue")
            {
                go.transform.localScale = new Vector3(0, 0, 0);

            }
        }

    }
    /// <summary>
    /// Scales up an object with LeanTween.
    /// Method by: Jonas
    /// </summary>
    public void ScaleUp()
    {
        foreach (GameObject go in objects)
        {
            LeanTween.scale(go, new Vector3(1, 1, 1), 0.3f).setDelay(delay);
        }
    }
    /// <summary>
    /// Scales down an object with LeanTween.
    /// Method by: Jonas
    /// </summary>
    public void ScaleDown()
    {
        foreach (GameObject go in objects)
        {
            LeanTween.scale(go, new Vector3(0, 0, 0), 0.3f).setDelay(delay);
        }
    }
}
