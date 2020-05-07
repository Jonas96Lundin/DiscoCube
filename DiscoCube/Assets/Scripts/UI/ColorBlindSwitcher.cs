using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlindSwitcher : MonoBehaviour
{
    private bool symbolSwitch;

    public void ColorBlindModeSwitch()
    {
        symbolSwitch =! symbolSwitch;

        GameObject[] symbols = GameObject.FindGameObjectsWithTag("Symbol");

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
