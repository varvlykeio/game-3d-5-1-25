using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using GameEv;

namespace TextReader{

    public class TXTReader : MonoBehaviour{

        [SerializeField] TextAsset file;
        public GameEvents events;

        // Start is called before the first frame update
        void DeSynthesiseList(string lines, out string comments, out string values){
            
            
            
                string[] split = lines.Split('!');
                values = split[0];
                comments = split[1];
                
            
            
        }
        public string[] VarList = new string[25];
        public string[] ComList = new string[25];
        
        void Start(){
            string[] CompleteList = file.text.Split('\n');
            string comments;
            string values;
            
            for(int i = 0; i < CompleteList.Length; i++){
            DeSynthesiseList(CompleteList[i], out comments, out values);
            //Debug.Log(comments + " ! " + values);
            VarList[i] = values;
            ComList[i] = comments;
            }
            SendValues(VarList);
           
            
            
        }

        string[] SynthesizeList(string[] comments, string[] values){
            string[] CompleteList = new string[comments.Length];
            for (int i = 0; i < comments.Length; i++)
            {
                CompleteList[i] =  values[i]+ " ! " + comments[i];
            }
            return CompleteList;
                
        }



        

        void SendValues(string[] VarList){
        
            events.rtime = float.Parse(VarList[0]);

        }
        
        
        void OnApplicationQuit(){
            string[] CompleteList = SynthesizeList(ComList, VarList);
            File.WriteAllLines("Assets/Settungs.txt", CompleteList);
        }

    }
}


