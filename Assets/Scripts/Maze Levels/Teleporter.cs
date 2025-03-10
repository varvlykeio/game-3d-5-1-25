using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Canvas;
    public GameObject Player;
    public GameEvents events;


    public void Negative(){
        Canvas.SetActive(false);
        events.CursorLock = true;
    }

    public void Affirmative(){
        Player.transform.position = new Vector3(-238, -4f, -36);
        Canvas.SetActive(false);
        events.CursorLock = true;
        events.Maze = true;
    }
}
