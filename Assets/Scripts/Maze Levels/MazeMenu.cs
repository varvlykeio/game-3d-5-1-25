using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
using Unity.VisualScripting;
public class MazeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameEvents events;
    void OnTriggerEnter()
    {
        events.CursorLock = false;
    }
    void OnTriggerExit()
    {
        events.CursorLock = true;
    }
}
