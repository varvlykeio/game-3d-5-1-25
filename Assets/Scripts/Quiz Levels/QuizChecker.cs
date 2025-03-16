using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC;
using System.Data.Common;
using JetBrains.Annotations;
using System;
using GameEv;




namespace QuizCol {

    public class QuizCols : MonoBehaviour{

       private bool activate;
        public bool pusher;
        //public GameObject wall;
        [SerializeField]    GameEvents          events                  = null;
        [SerializeField]    int          level;
        [SerializeField]    int          dif;
        [SerializeField]    bool         mazequiz;
        private UiAppear component;
         public void OnTriggerEnter(){
            
            activate = true;
            if (mazequiz == true){
                events.teleport = true;
            }
        }

        public void Update(){

            if (activate == true){
                if(Input.GetKeyDown("i")){

                    pusher = true;
                    events.CursorLock = false;
                    events.QuizStart = true;
                    events.Difficulty = dif;
                    events.level = level;
                    //wall.SetActive(true);
                    //events.currentlevel = level;
                    events.QuizActive = true;
                    Destroy(GetComponent("UiAppear"));
                    // AddComponentMenu
                }
            }
        }
        

        public void OnTriggerExit(){
            
            activate = false;
            if (mazequiz == true){
                events.teleport = true;
            }
            
        }
        
    }

}
