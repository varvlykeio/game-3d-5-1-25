using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
using Unity.VisualScripting;
public class MazeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvents events;
    void Update(){
        if(events.isPaused == false){
            if (events.triggered== true)
            {
            events.CursorLock = false;
            }
            else{
                events.CursorLock = true; 
            }
        }
    }
}
