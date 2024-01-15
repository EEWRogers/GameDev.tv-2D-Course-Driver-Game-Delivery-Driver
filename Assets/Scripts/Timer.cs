using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] int timeLimit = 30;
    [SerializeField] int timeIncrease = 10;

    TMP_Text timerText;

    void Awake() 
    {
        if (GetComponent<TMP_Text>() == null) { return; }
        timerText = GetComponent<TMP_Text>();
    }

    void Start() 
    {
        StartCoroutine(ReduceTimer());
    }
    
    void Update()
    {
        TimeSpan remainingTime = TimeSpan.FromSeconds(timeLimit);

        timerText.text = "Time Remaining: " + remainingTime.Minutes + ":" + remainingTime.Seconds;
    }

    IEnumerator ReduceTimer()
    {
        timeLimit--;

        yield return new WaitForSeconds(1f);

        StartCoroutine(ReduceTimer());
    }

    public void AddTime()
    {
        timeLimit += timeIncrease;
    }
}
