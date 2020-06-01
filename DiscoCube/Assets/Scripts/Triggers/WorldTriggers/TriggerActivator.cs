using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField]
    ColorManager colorManager;
    [SerializeField]
    string[] trigger;

    bool tempbool = false;

    public void Update()
    {

    }
    
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == trigger[0])
        {
            tempbool =! tempbool;
        }

        if (tempbool)
        {
            ////TODO
            ////Gör om till metod
            //GateTrigger t = collider.GetComponent<GateTrigger>();
            //if (collider.gameObject.tag == trigger[0])
            //{
            //    if (t.GetTriggerColor() == colorManager.currentColor)
            //    {
            //        Debug.Log("Success!! \nTrigger: " + t.GetTriggerColor().ToString() + " ColorManager: " + colorManager.currentColor.ToString());
            //    }
            //    else
            //    {
            //        Debug.Log("Failure!! \nTrigger: " + t.GetTriggerColor().ToString() + " ColorManager: " + colorManager.currentColor.ToString());
            //    }
            //}

        }

    }

}
