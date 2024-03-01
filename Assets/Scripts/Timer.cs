using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class Timer : MonoBehaviour
{
    public GameObject timer;

    private int seconds = 0;
    void Start()
    {
        FindTimerGameObject();
        InvokeRepeating("Tick", 0f, 1f);
    }
    
    void Update()
    {
        UpdateTimerGameObject();
    }
    void Tick()
    {
        seconds++;
    }
    string GetFormattedTime()
    {
        int minutes = seconds / 60;
        int remainingSeconds = seconds % 60;

        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
    void UpdateTimerGameObject()
    {
        TextMeshProUGUI timerText = timer.gameObject.GetComponent<TextMeshProUGUI>();
        timerText.text = GetFormattedTime();        
    }
    void FindTimerGameObject()
    {
        timer = GameObject.Find("Time Elapsed Count");
    }

}
