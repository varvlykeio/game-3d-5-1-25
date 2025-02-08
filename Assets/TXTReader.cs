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

        public List<string> VarList = new List<string>();
        public List<string> ComList = new List<string>();
        void Start(){
            List<string> CompleteList = new List<string>(file.text.Split('\n'));
            string comments;
            string values;
            VarList.Clear(); // Clear the list before adding new values because for some fucking reason
            ComList.Clear(); // the list is initialized with 25 empty strings
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
                CompleteList.Add(values[i] + "!" + comments[i]);
            }
            return CompleteList;
                
        }

        void DeSynthesiseList(string lines, out string comments, out string values){ 
            string[] split = lines.Split('!');
            values = split[0];
            comments = split[1].Replace("\r", "").Replace("\n", "");
        }

        void SendValues(List<string> VarList){    
            if (float.TryParse(VarList[0], out float rtime))
            {
                events.rtime = rtime;
            }
            else
            {
                Debug.LogError($"Failed to parse '{VarList[0]}' as float.");
            }
        }
        
        void OnApplicationQuit(){
           List<string> CompleteList = SynthesizeList(ComList, VarList);
           File.WriteAllText("Assets/Settungs.txt", string.Join("\n", CompleteList).TrimEnd('\n'));
        }
    }
}


