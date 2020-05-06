using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMaterialChanger : MonoBehaviour
{
    public Material floor1;
    public Material floor2;
    public Material floor3;
    public Material floor4;
    public Material floor5;
    void Start()
    {
        Invoke("Floor1", 1.0f);

        
    }

    void Floor1()
    {
        GetComponent<Renderer>().material = floor1;

        Invoke("Floor2", 1.0f);
    }

    void Floor2()
    {
        GetComponent<Renderer>().material = floor2;

        Invoke("Floor3", 1.0f);
    }
    void Floor3()
    {
        GetComponent<Renderer>().material = floor3;

        Invoke("Floor4", 1.0f);
    }
    void Floor4()
    {
        GetComponent<Renderer>().material = floor4;

        Invoke("Floor5", 1.0f);
    }
    void Floor5()
    {
        GetComponent<Renderer>().material = floor5;

        Invoke("Floor1", 1.0f);
    }
}
