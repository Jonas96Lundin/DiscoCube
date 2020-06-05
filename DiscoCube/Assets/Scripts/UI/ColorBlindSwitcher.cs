using UnityEngine;

public class ColorBlindSwitcher : MonoBehaviour
{
    //Creator Raimon
    GameObject[] symbols;

    [SerializeField]
    GameObject checkmark;


    void Start()
    {
        symbols = GameObject.FindGameObjectsWithTag("Symbol");
        if (GameManager.symbolSwitch == false)
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(false);
            }
            checkmark.SetActive(false);
        }
        
    }

    public void ColorBlindModeSwitch()
    {
        GameManager.symbolSwitch =! GameManager.symbolSwitch;

        if (GameManager.symbolSwitch)
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(true);
            }
            checkmark.SetActive(true);
        }
        else
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(false);
            }
            checkmark.SetActive(false);
        }

    }
}
