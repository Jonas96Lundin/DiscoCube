using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    

    public void OnTriggerEnter(Collider Goal)
    {
        Win();
    }
    public GameObject completeLevelUI;
   
   
    void Win()
    {
        completeLevelUI.SetActive(true);
    }

}
