using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSwitch : MonoBehaviour
{
    WinTrigger winTriggerScrippt;
    public GameObject player;
    public Transform switchTrigger;
    public bool trigger;
    [SerializeField]
    Material green, red;
    Material currentColor;


    void Start()
    {
        winTriggerScrippt = FindObjectOfType<WinTrigger>();
        currentColor = red;
    }
    public void OnTriggerEnter(Collider other)
    {
        trigger = true;
        FindObjectOfType<AudioManager>().Play("Switch");
    }

    void Update()
    {
        if (trigger)
        {
            currentColor = green;
            this.GetComponent<Renderer>().sharedMaterial = currentColor;
        }
    }
}
