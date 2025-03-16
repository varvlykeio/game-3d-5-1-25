using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CanvasEnter;
    public GameObject CanvasExit;
    public GameObject Player;
    public GameEvents events;


    public void NegativeEnter(){
        CanvasEnter.SetActive(false);
        events.CursorLock = true;
    }

    public void AffirmativeEnter(){
        Player.transform.position = new Vector3(-238, -4f, -36);
        Player.transform.rotation = Quaternion.Euler(0, 90, 0);
        CanvasEnter.SetActive(false);
        events.CursorLock = true;
        events.Maze = true;
    }
    public void NegativeExit(){
        CanvasExit.SetActive(false);
        events.CursorLock = true;
    }

    public void AffirmativeExit(){
        Player.transform.position = new Vector3(-238, -4f, -36);
        CanvasExit.SetActive(false);
        events.CursorLock = true;
        events.Maze = false;
    }
}
