using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Create a dialogue script.
/// Created by: Jonas
/// </summary>
[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
