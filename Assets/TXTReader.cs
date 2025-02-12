using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using GameEv;
using Unity.VisualScripting;

namespace TextReader{

    public class TXTReader : MonoBehaviour{

        [SerializeField] TextAsset file;
        public GameEvents events;

        // Start is called before the first frame update

        public List<string> VarList = new List<string>();
        public List<string> ComList = new List<string>();

        void Start(){
            List<string> CompleteList = new List<string>(file.text.Split('\n'));
            string comments;
            string values;
            VarList.Clear(); // This was needed because before it was adding 25 empty strings to the list
            ComList.Clear(); // Turns out, for some reason, it was a set value in the unity editor.... 
            // Now it is cleared as a security measure
            foreach (string line in CompleteList)
            {
                DeSynthesiseList(line, out comments, out values);
                VarList.Add(values);
                ComList.Add(comments);
            }
            SendValues(VarList);
           
          
            
        }

        List<string> SynthesizeList(List<string> comments,List<string> values){
            List<string> CompleteList = new List<string>();
            for (int i = 0; i < comments.Count; i++)
            {
                CompleteList.Add(values[i] + " ! " + comments[i]);
            }
            return CompleteList;
                
        }

        void DeSynthesiseList(string lines, out string comments, out string values){ 
            string[] split = lines.Split('!');
            values = split[0].Replace(" " , "");
            comments = split[1].Replace("\r", "").Replace("\n", "").Replace(" " , "");
        }

        void SendValues(List<string> VarList){    
            
            for (int i = 0; i < VarList.Count; i++)
            {
                string variableName = ComList[i];
                var fieldType = typeof(GameEvents).GetField(variableName).FieldType;
                Debug.Log(fieldType);
                object value = System.Convert.ChangeType(VarList[i], fieldType);
                value = VarList[i];
                typeof(GameEvents).GetField(variableName).SetValue(events, value);
            }
        }
        
        void OnApplicationQuit(){
           List<string> CompleteList = SynthesizeList(ComList, VarList);
           File.WriteAllText("Assets/Settungs.txt", string.Join("\n", CompleteList).TrimEnd('\n'));
        }
    }
}


