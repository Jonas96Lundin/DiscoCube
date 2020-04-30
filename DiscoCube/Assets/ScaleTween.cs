using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void ScaleUp()
    {
        foreach (GameObject go in objects)
        {
            LeanTween.scale(go, new Vector3(1, 1, 1), 0.3f).setDelay(delay);
        }
    }
    public void ScaleDown()
    {
        foreach (GameObject go in objects)
        {
            LeanTween.scale(go, new Vector3(0, 0, 0), 0.3f).setDelay(delay);
        }
    }
}
