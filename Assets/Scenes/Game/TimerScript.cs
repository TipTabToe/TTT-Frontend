using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Creates timer for game
public class TimerScript : MonoBehaviour
{
    public static float timeRemaining = 25;
    public static bool timerIsRunning = false;
    public TMP_Text timer;
    public static bool answered = false;
    public GameScript gameScript;
    
    void Start()
    {
        timerIsRunning = true;
    }

    // Updates timer
    void Update()
    {
        if (timerIsRunning && !answered)
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
                gameScript.TimeRunsOut();

            }
        }
    }

    // Resets timer between questions
    public static void ResetTimer() {
        timeRemaining = 25;
        answered = false;
        timerIsRunning = true;
    }
}