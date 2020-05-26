using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCodeInput : MonoBehaviour
{
    [SerializeField]
    SceneFader fader;
    public void CheckCode(string input)
    {
        switch (input.ToLower())
        {
            //Level2
            case "12345678":
                fader.FadeTo("Level2");
                break;
            //Level3
            case "nolimits":
                fader.FadeTo("Level3");
                break;
            //Level4
            case "thewalls":
                fader.FadeTo("Level4");
                break;
            //Level5
            case "morecube":
                fader.FadeTo("Level5");
                break;
            //Level6
            case "notriang":
                fader.FadeTo("Level6");
                break;
            //Level7
            case "cubelord":
                fader.FadeTo("Level7");
                break;
            default:
                break;
        }
    }
}
