using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameEv;
using Resolution;
public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] public GameEvents events;
    
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (!events.isPaused)
        {
            events.rtime -= Time.deltaTime; 
            int minutes = Mathf.FloorToInt(events.rtime / 60);
            int seconds = Mathf.FloorToInt(events.rtime % 60); 
            timerText.text = string.Format("Remaining Time: " + "{0:00}:{1:00}", minutes, seconds);
            if (events.rtime <= 0)
            {
                events.isPaused = true;
                events.rtime = 0;
                timerText.text = "Time's up!";
            
                
            }
        }
    }
}
