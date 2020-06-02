using UnityEngine;
using UnityEngine.EventSystems;

public class LevelCodeInput : MonoBehaviour
{
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
            case "wrdchamp":
                fader.FadeTo("Level8");
                break;
            case "holddoor":
                fader.FadeTo("Level9");
                break;
            case "nowalls":
                fader.FadeTo("Level10");
                break;
            case "nospoon":
                fader.FadeTo("Level11");
                break;
            case "buttons!":
                fader.FadeTo("Level11");
                break;
            default:
                break;
        }
    }
}
