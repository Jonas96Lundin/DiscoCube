using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindSwitcher : MonoBehaviour
{
    private bool symbolSwitch;
    GameObject[] symbols;

    void Start()
    {
        symbols = GameObject.FindGameObjectsWithTag("Symbol");
        foreach (GameObject go in symbols)
        {
            go.SetActive(false);
        }
    }

    public void ColorBlindModeSwitch()
    {
        symbolSwitch =! symbolSwitch;

        if (symbolSwitch)
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(false);
            }
        }
    }
}
