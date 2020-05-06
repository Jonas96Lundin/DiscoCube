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
    
    public void OnTriggerEnter(Collider collider)
    {
        
        GateTrigger t = collider.GetComponent<GateTrigger>();
        if (collider.gameObject.tag == trigger[0])
        {
            if (t.GetTriggerColor() == colorManager.currentColor)
            {
                Debug.Log("Success!! \nTrigger: " + t.GetTriggerColor().ToString() + " ColorManager: " + colorManager.currentColor.ToString());
            }
            else
            {
                Debug.Log("Failure!! \nTrigger: " + t.GetTriggerColor().ToString() + " ColorManager: " + colorManager.currentColor.ToString());
            }
        }
    }

}
