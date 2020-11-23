using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text timer;
    
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timer.SetText(Mathf.RoundToInt(timeRemaining).ToString());
            }
            else
            {
                print("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}