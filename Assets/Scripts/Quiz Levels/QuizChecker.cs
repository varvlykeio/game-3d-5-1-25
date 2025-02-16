using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC;
using System.Data.Common;
using JetBrains.Annotations;
using System;
using GameEv;
using UnityEditor.UI;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;


namespace QuizCol {

    public class QuizCols : MonoBehaviour{

       private bool activate;
        public bool pusher;
        [SerializeField]    GameEvents          events                  = null;
        [SerializeField]    int          level;
        [SerializeField]    int          dif;
        private UiAppear component;
         public void OnTriggerEnter(){
            
            activate = true;

        }

        public void Update(){

            if (activate == true){
                if(Input.GetKeyDown("i")){

                    pusher = true;
                    events.CursorLock = false;
                    events.QuizStart = true;
                    events.Difficulty = dif;
                    //events.currentlevel = level;
                    events.QuizActive = true;
                    Destroy(GetComponent("UiAppear"));
                    // AddComponentMenu
                }
            }
        }
        

        public void OnTriggerExit(){
            
            activate = false;
            
        }
        
    }

}
