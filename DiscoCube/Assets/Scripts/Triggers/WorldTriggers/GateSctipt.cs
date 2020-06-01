using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSctipt : MonoBehaviour
{
    public GameObject wallToMove;
    public void OnTriggerEnter(Collider collider)
    {
        //Starta movement av vägg?
        wallToMove.transform.Translate(new Vector3(1,0,0));
    }

}
