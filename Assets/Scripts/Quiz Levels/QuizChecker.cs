using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MyVars;
using System.Data.Common;
using JetBrains.Annotations;
using System;
using GameEv;


namespace QuizCol {

    public class QuizCols : MonoBehaviour{

       private bool activate;
        public bool pusher;
           [SerializeField]    GameEvents          events                  = null;
           [SerializeField]    int          level;
           [SerializeField]    int          dif;
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
                    events.currentlevel = level;

                }
            }
        }

        public void OnTriggerExit(){
            
            activate = false;
            
        }
        
    }

}
