using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField]
    ColorManager colorManager;

    public void OnTriggerEnter(Collider collider)
    {
        GateTrigger t = collider.GetComponent<GateTrigger>();
        if (collider.gameObject.tag == "GateTrigger")
        {
            if (t.GetTriggerColor() == colorManager.currentColor)
            {
                Debug.Log("Samma färg");
            }
            else
            {
                Debug.Log("NEJ FEL FÄRG!!");
            }
        }
    }

}
