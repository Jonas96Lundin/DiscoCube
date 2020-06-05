using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    //Creator Raimon

    [HideInInspector]
    public bool triggerActivated = false, currentlyOnTrigger = false;
    public ColorManager.CubeColors triggerColor;
    [SerializeField]
    ParticleSystem ps;

    private Color panelColor;
    private Renderer renderer;

    void Start()
    {
        Transform[] tempGO = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < tempGO.Length; i++)
        {
            if (tempGO[i].name == "Base")
            {
                renderer = tempGO[i].GetComponent<Renderer>();
            }
            switch (triggerColor)
            {
                case ColorManager.CubeColors.blue:
                    if (tempGO[i].name == "Star")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                case ColorManager.CubeColors.green:
                    if (tempGO[i].name == "Triangle")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                case ColorManager.CubeColors.purple:
                    if (tempGO[i].name == "Circle")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                case ColorManager.CubeColors.yellow:
                    if (tempGO[i].name == "Peace")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                case ColorManager.CubeColors.red:
                    if (tempGO[i].name == "Heart")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                case ColorManager.CubeColors.teal:
                    if (tempGO[i].name == "Square")
                    {
                        tempGO[i].gameObject.SetActive(true);
                    }
                    break;
                default:
                    break;
            }
        }
        SetColor();
        renderer.material.SetColor("_Color", panelColor);
    }

    void SetColor()
    {
        switch (triggerColor)
        {
            case ColorManager.CubeColors.blue:
                panelColor = Color.blue;
                break;
            case ColorManager.CubeColors.green:
                panelColor = Color.green;
                break;
            case ColorManager.CubeColors.purple:
                panelColor = new Color(0.803f, 0f, 1f);
                break;
            case ColorManager.CubeColors.yellow:
                panelColor = Color.yellow;
                break;
            case ColorManager.CubeColors.red:
                panelColor = Color.red;
                break;
            case ColorManager.CubeColors.teal:
                panelColor = new Color(0,1,1);
                break;
            default:
                break;
        }
    }
    public void SendUpdateRequest()
    {
        GetComponentInParent<SwitchController>().DoSwitchUpdate();
        if (triggerActivated)
        {
            ps.Stop();
        }
        else
        {

            ps.Play();
        }
    }

}
