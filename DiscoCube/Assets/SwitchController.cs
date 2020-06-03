using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public ColorSwitch[] switches;
    public bool allSwitchesTrue;
    void Start()
    {
        //Finds all the switcher currently used in object
        switches = GetComponentsInChildren<ColorSwitch>();
    }

    public void DoSwitchUpdate()
    {
        int switchInt = 0;
        for (int i = 0; i < switches.Length; i++)
        {
            if (switches[i].triggerActivated)
            {
                switchInt++;
            }
        }
        if (switchInt == switches.Length)
        {
            allSwitchesTrue = true;
            AudioManager.instance.Play("GateFX");
        }
        else
        {
            allSwitchesTrue = false;
        }
    }
    
}
