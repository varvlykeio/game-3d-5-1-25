using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEv;
using UnityEditor;
using TextReader;
using Unity.VisualScripting;
using UnityEngine.UIElements;
public class StartMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SettingButtons;
    public GameObject MenuButtons;
    public GameObject TeacherSettingButtons;
    public GameObject score;
    public GameObject timer;
    public GameObject SettingNotSaved;
    public GameObject SettingSaved;
    public GameEvents events;
    public TXTReader Text;
    public int TTime;
    public int TimeImpact;  
    public int CoinScore;  
    int p;
    int p2;

    public void StartGame(){
        events.isPaused = false;
        MenuCanvas.SetActive(false);
        events.CursorLock = true;
        timer.SetActive(true);
        score.SetActive(true);
        events.MenuOpen = false; 
    }
    
    /// <summary>
    /// Function that is called to save the settings to the TXT file and the Variable Holder(GameEvents)
    /// </summary>
    public void SaveSettings(){
        
        if (TimeImpact>=0 && TimeImpact<=100){
            events.timegravity = TimeImpact; 
            Debug.Log(CoinScore);

            SendValue("TotalTime","rtime", TTime);
            SendValue("CoinImportance", CoinScore);
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
    }

    public void ReadTimeImpact( string s){
        if (!string.IsNullOrEmpty(s)){
            TimeImpact = int.Parse(s);
        }
    }
    public void ReadCoinScore( string s){
        if (!string.IsNullOrEmpty(s)){
            CoinScore = int.Parse(s);
        }
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
    
    
    ///<summary>
    /// Function that send values from the setting panel to the save file and the variable holder(GameEvents).
    /// >Add a second string between the first string and the Value for it to reference two variables in the GameEvents
    /// >Add a second string after the value to reference two variables in save file
    /// >Add a second string after the first string and an int after the value to reference two variables in both locations
    /// </summary>
    public void SendValue(string variableName, object variable){
        p = Text.ComList.IndexOf(variableName);
        if (variable is string strValue){
            Text.VarList[p] = strValue;
            typeof(GameEvents).GetField(variableName).SetValue(events, strValue);
        }
        else if (variable is int intValue){
            Text.VarList[p] = intValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, intValue);
        }
        else if (variable is float floatValue){
            Text.VarList[p] = floatValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, floatValue);
        }
        else if (variable is bool boolValue){
            Text.VarList[p] = boolValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, boolValue);
        }      
    }
    public void SendValue(string variableName,string variableName2, object variable){
        p = Text.ComList.IndexOf(variableName);
        if (variable is string strValue){
            Text.VarList[p] = strValue;
            typeof(GameEvents).GetField(variableName).SetValue(events, strValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, strValue);
        }
        else if (variable is int intValue){
            Text.VarList[p] = intValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, intValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, intValue);
        }
        else if (variable is float floatValue){
            Text.VarList[p] = floatValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, floatValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, floatValue);
        }
        else if (variable is bool boolValue){
            Text.VarList[p] = boolValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, boolValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, boolValue);
        }      
    }
     public void SendValue(string variableName, object variable,string variableName2){
        p = Text.ComList.IndexOf(variableName);
        p2 = Text.ComList.IndexOf(variableName2);   
        if (variable is string strValue){
            Text.VarList[p] = strValue;
            Text.VarList[p2] = strValue;
            typeof(GameEvents).GetField(variableName).SetValue(events, strValue);
        }
        else if (variable is int intValue){
            Text.VarList[p] = intValue.ToString();
            Text.VarList[p2] = intValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, intValue);
        }
        else if (variable is float floatValue){
            Text.VarList[p] = floatValue.ToString();
            Text.VarList[p2] = floatValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, floatValue);
        }
        else if (variable is bool boolValue){
            Text.VarList[p] = boolValue.ToString();
            Text.VarList[p2] = boolValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, boolValue);
        }      
    }
     public void SendValue(string variableName,string variableName2, object variable,int ch){
        p = Text.ComList.IndexOf(variableName);
        p2 = Text.ComList.IndexOf(variableName2);
        if (variable is string strValue){
            Text.VarList[p] = strValue;
            Text.VarList[p2] = strValue;
            typeof(GameEvents).GetField(variableName).SetValue(events, strValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, strValue);
        }
        else if (variable is int intValue){
            Text.VarList[p] = intValue.ToString();
            Text.VarList[p2] = intValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, intValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, intValue);
        }
        else if (variable is float floatValue){
            Text.VarList[p] = floatValue.ToString();
            Text.VarList[p2] = floatValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, floatValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, floatValue);
        }
        else if (variable is bool boolValue){
            Text.VarList[p] = boolValue.ToString(); 
            Text.VarList[p2] = boolValue.ToString();
            typeof(GameEvents).GetField(variableName).SetValue(events, boolValue);
            typeof(GameEvents).GetField(variableName2).SetValue(events, boolValue);
        }      
    }
}
