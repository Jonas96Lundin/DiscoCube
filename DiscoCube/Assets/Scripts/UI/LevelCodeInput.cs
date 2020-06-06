using UnityEngine;
using UnityEngine.EventSystems;

public class LevelCodeInput : MonoBehaviour
{
    //Creator Raimon

    [SerializeField]
    SceneFader fader;
    [SerializeField]
    GameObject inputField;

    void OnEnable()
    {
        //Clear selected object in event system.
        EventSystem.current.SetSelectedGameObject(null);
        //Set a new object in event system.
        EventSystem.current.SetSelectedGameObject(inputField);
    }
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
            //Level8
            case "Snnnake":
                fader.FadeTo("Level8");
                break;
            //Level9
            case "Corn":
                fader.FadeTo("Level9");
                break;
            //Level10
            case "wrdchamp":
                fader.FadeTo("Level10");
                break;
            //Level11
            case "holddoor":
                fader.FadeTo("Level11");
                break;
            //Level12
            case "nowalls":
                fader.FadeTo("Level12");
                break;
            //Level13
            case "nospoon":
                fader.FadeTo("Level13");
                break;
            //Level14
            case "buttons!":
                fader.FadeTo("Level14");
                break;
            //Level15
            case "kekwlul":
                fader.FadeTo("Level15");
                break;
            //Level16
            case "funkey":
                fader.FadeTo("Level16");
                break;
            //Level17
            case "btnhell":
                fader.FadeTo("Level17");
                break;
            //Level18
            case "forgods":
                fader.FadeTo("Level18");
                break;
            //Secret Level
            case "iddqd":
                fader.FadeTo("Level19");
                break;
            default:
                break;
        }
    }
}
