using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] float startTime; // start time value
    float currentTime; // current time value
    bool timerStarted = false; // timer started or not
    [SerializeField] TMP_Text timerText; // text to display timer
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime; // Suptracts the previous fram's duration
            updateTimer(currentTime);

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerStarted = false;
                Debug.Log("Timer has ended");
            }
        }
    }
    
    void updateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
}
