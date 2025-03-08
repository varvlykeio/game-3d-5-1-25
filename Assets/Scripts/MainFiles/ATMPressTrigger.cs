using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameEv;

public class ATMPressTrigger : MonoBehaviour
{        
    public GameEvents events;
    
    void OnTriggerEnter()
    {
        events.triggered = true; 
    }
    public void OnTriggerExit()
    {
        events.triggered = false;
    } 
}
