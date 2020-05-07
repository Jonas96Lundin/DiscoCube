using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField]
    ColorManager.CubeColors color;


    public ColorManager.CubeColors GetTriggerColor()
    {
        return color;
    }
    public void TriggerColor()
    {

    }

}
