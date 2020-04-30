﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;

    [SerializeField] float totalTime;
    [SerializeField] Text countdownText;

    public bool isActive; // Jonas kod

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        isActive = true;
        if (isActive) // Jonas kod
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                isActive = false;
            }
        }
    }
}
