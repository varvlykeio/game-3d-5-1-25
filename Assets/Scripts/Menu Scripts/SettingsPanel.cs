using UnityEngine;
using GameEv;


public class SettingsPanel : MonoBehaviour
{
    public GameObject Settings;
    public GameEvents events;

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.M) && !events.QuizActive && !events.GameFinished && !events.MenuOpen && Settings != null){
            Settings.SetActive(!Settings.activeSelf);
            if (Settings.activeSelf){
                events.CursorLock = false;
                events.isPaused = true;
            }
            else{
                events.CursorLock = true;
                events.isPaused = false;
            }    
        }
    }
}