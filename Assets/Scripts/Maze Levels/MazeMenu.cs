using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
public class MazeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;
    public GameEvents events;
    public bool appear = false;

    void Start()
    {
        Menu.SetActive(false);  
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&  events.triggered== true)
        {
            if (appear)
            {
                Menu.SetActive(false);
                appear = false;
                events.CursorLock = true;
            }
            else
            {
                Menu.SetActive(true);
                appear = true;
                events.CursorLock = false;
            }
        }
    }
}
