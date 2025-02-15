using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
using UnityEditor;
using TextReader;
using Unity.VisualScripting;
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
    public TXTReader Text;
    public int TTime;
    public int TimeImpact;

    public void StartGame(){
        events.isPaused = false;
        MenuCanvas.SetActive(false);
        events.CursorLock = true;
        MainUI.SetActive(true);
        events.MenuOpen = false; 
    }
    
    /// <summary>
    /// Function that is called to save the settings to the TXT file and the Variable Holder(GameEvents)
    /// </summary>
    public void SaveSettings(){
        
        if (TimeImpact>=0 && TimeImpact<=100){
            events.timegravity = TimeImpact; 
            events.rtime = TTime;
            Text.VarList[0] = TTime.ToString();
            Debug.Log(Text.VarList[0]);
            events.TotalTime = TTime;
            StartCoroutine(SaveIcon());
            SwitchToMainMenu();
        }
        else{
            StartCoroutine(NotSavedIcon());
        }
        Debug.Log("Time: " + events.rtime + " Time Impact: " + events.timegravity);
    }
    public void ReadTime(string s){
        if (!string.IsNullOrEmpty(s)){
            TTime = int.Parse(s);
        }
        //Debug.Log("Time: " + TTime);
    }
    
    public void ReadTimeImpact( string s){
        if (!string.IsNullOrEmpty(s)){
            TimeImpact = int.Parse(s);
        }
        //Debug.Log("Time Impact: " + TimeImpact);
    }


    /// <summary>
    /// Function that is called to show the saved icon
    /// </summary>
    /// <returns></returns>
    public IEnumerator SaveIcon(){
        SettingSaved.SetActive(true);
        yield return new WaitForSeconds(3);
        SettingSaved.SetActive(false);   
    }

    
    /// <summary>
    /// Function that is called to show the not saved icon
    /// </summary>
    /// <returns></returns>
        public IEnumerator NotSavedIcon(){
        SettingNotSaved.SetActive(true);
        yield return new WaitForSeconds(3);
        SettingNotSaved.SetActive(false);  
    }


    /// <summary>
    /// Function that is called to switch to the main menu
    /// </summary>
    public void SwitchToMainMenu(){
        MenuButtons.SetActive(true);
        TeacherSettingButtons.SetActive(false);
        SettingButtons.SetActive(false);
    }


    /// <summary>
    /// Function that is called to switch to the teacher settings
    /// </summary>
    public void SwitchToTeacherSettings(){
        TeacherSettingButtons.SetActive(true);
        MenuButtons.SetActive(false);
        SettingButtons.SetActive(false);
    }


    /// <summary>
    /// Function that is called to switch to the main settings
    /// </summary>
    public void SwitchToSettings(){
        SettingButtons.SetActive(true);
        MenuButtons.SetActive(false);
        TeacherSettingButtons.SetActive(false);
    }
    
}
