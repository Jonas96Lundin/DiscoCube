using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public int score;

    void Start()
    {

    }
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        AddScore();
    }
    void AddScore()
    {
        score++;
    }
}
