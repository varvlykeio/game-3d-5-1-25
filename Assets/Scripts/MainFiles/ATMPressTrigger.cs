using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameEv;

public class ATMPressTrigger : MonoBehaviour
{        
    public GameEvents events;

    public void Start()
    {
        events.triggered = false;
    }
    
    void OnTriggerEnter()
    {
        events.triggered = true; 
        Debug.Log("Triggered");
    }
    public void OnTriggerExit()
    {
        events.triggered = false;
    } 
}
