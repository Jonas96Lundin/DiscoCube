using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    //[SerializeField]
    public Material startMaterial;
    [SerializeField]
    public Material glowMaterial;
    [SerializeField]
    Renderer coloredObject;
    [SerializeField]
    bool isGlowing;
    private void Start()
    {
        Debug.LogError(startMaterial);
        Debug.LogError(coloredObject.material);
        
        //coloredObject.material = startMaterial;
    }

    public void SetColorToGlow(string winningColor)
    {
        Debug.LogError("Start color is: " + coloredObject.material.ToString());
        //Debug.LogError(winningColor + " " + startColorString.ToLower());
        //Debug.LogError(startColorString.ToLower() == winningColor);

        //string startColorString = coloredObject.material.ToString().Replace(" (Instance) (UnityEngine.Material)", "");
        string startColorString = startMaterial.ToString().Replace(" (UnityEngine.Material)", "");
        if (startColorString.ToLower() == winningColor)
        {
            //coloredObject.sharedMaterial = glowMaterial;
            GameObject[] cubePlane = GameObject.FindGameObjectsWithTag("Teal");
            foreach(GameObject go in cubePlane)
            {
                go.GetComponent<Renderer>().sharedMaterial = glowMaterial;
            }
            Debug.Log("COLOR SHOULD BE GLOWING");
            isGlowing = true;
        }
    }
}
