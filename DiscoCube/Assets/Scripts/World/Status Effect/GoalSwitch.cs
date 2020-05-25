using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalSwitch : MonoBehaviour
{
    WinTrigger winTriggerScrippt;
    public GameObject player;
    public Transform switchTrigger;
    public bool trigger;
    [SerializeField]
    Material green, red;
    Material currentColor;

    [SerializeField]
    Text gate;

    void Start()
    {
        winTriggerScrippt = FindObjectOfType<WinTrigger>();
        currentColor = red;
    }
    public void OnTriggerEnter(Collider other)
    {
        trigger = true;
        FindObjectOfType<AudioManager>().Play("Switch");
        gate.text = "Goal Open";
    }

    void Update()
    {

        if (trigger)
        {
            currentColor = green;
            this.GetComponent<Renderer>().sharedMaterial = currentColor;
            winTriggerScrippt.enabled = true;
        }
        else
        {
            winTriggerScrippt.enabled = false;
        }
    }
}
