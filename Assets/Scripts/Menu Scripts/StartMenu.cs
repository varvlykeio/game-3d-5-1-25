using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
using UnityEditor;
public class StartMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SettingButtons;
    public GameObject MenuButtons;
    public GameObject TeacherSettingButtons;
    public GameObject MainUI;
    public GameObject SettingNotSaved;
    public GameObject SettingSaved;
    public GameEvents events;
    public int TTime;
    public int TimeImpact;

    public void StartGame(){
        events.isPaused = false;
        MenuCanvas.SetActive(false);
        events.CursorLock = true;
        MainUI.SetActive(true);
    }

    public void Settings(){
        MenuButtons.SetActive(false);
        SettingButtons.SetActive(true);    
    }
    public void TeacherSettings(){
        MenuButtons.SetActive(false);
        TeacherSettingButtons.SetActive(true);
    }
    public void Back(){
        MenuButtons.SetActive(true);
        SettingButtons.SetActive(false);
        TeacherSettingButtons.SetActive(false);
    }
    public void SaveSettings(){
        
        if (TimeImpact>=0 && TimeImpact<=100){
            events.timegravity = TimeImpact; 
            events.rtime = TTime;
            SettingNotSaved.SetActive(false);
            SettingSaved.SetActive(true);
        }
        else{
            SettingNotSaved.SetActive(true);
            SettingSaved.SetActive(false);
        }
        Debug.Log("Time: " + events.rtime + " Time Impact: " + events.timegravity);
    }

    public void ReadTime(string s){
        TTime = int.Parse(s);
        Debug.Log("Time: " + TTime);
    }
    public void ReadTimeImpact( string s){
        TimeImpact = int.Parse(s);
        Debug.Log("Time Impact: " + TimeImpact);
    }
}
