using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class TXTReader : MonoBehaviour
{

    [SerializeField] TextAsset file;

    // Start is called before the first frame update
    void DeSynthesiseList(string lines, out string comments, out string values){
        
        
        
            string[] split = lines.Split('!');
            values = split[0];
            comments = split[1];
            
        
        
    }
    void Start(){
        string[] CompleteList = file.text.Split('\n');
        string comments;
        string values;
        
        for(int i = 0; i < CompleteList.Length; i++){
        DeSynthesiseList(CompleteList[i], out comments, out values);
        Debug.Log(comments + " ! " + values);
        }
    }
    
    /*string[] SynthesizeList(string[] comments, string[] values){
        string[] CompleteList = new string[comments.Length];
        for (int i = 0; i < comments.Length; i++)
        {
            CompleteList[i] =  values[i]+ " ! " + comments[i];
        }
        return CompleteList;
        
    }*/

    // Update is called once per frame
    void OnApplicationQuit(){
       //SynthesizeList(comments, values); 
    }
}
