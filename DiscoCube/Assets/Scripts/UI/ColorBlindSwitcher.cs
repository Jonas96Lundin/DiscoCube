using UnityEngine;

public class ColorBlindSwitcher : MonoBehaviour
{
    GameObject[] symbols;


    void Start()
    {
        
        symbols = GameObject.FindGameObjectsWithTag("Symbol");
        if (GameManager.symbolSwitch == false)
        {
            foreach (GameObject go in symbols)
            {
                go.SetActive(false);
            }
        }
        
    }

    public void ColorBlindModeSwitch()
    {
        GameManager.symbolSwitch =!GameManager.symbolSwitch;
        Debug.Log(GameManager.symbolSwitch);

        if (GameManager.symbolSwitch)
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
