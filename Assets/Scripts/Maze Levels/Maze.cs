using System.Collections;
using System;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEditor;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;
using CC;
using GameEv;
using UnityEngine.UIElements;


public class Maze1 : MonoBehaviour

{
	public GameObject ATMPrmoufa;
									  // MazePos[ No. , x/y/z....]                    v-int-v
                                   //      x       ,     y     ,       z     , RotationY
	public float[,] MazePos =  {{  -237.4f      ,  -4.625f  ,  -52.60674f , 180},    
								{  -187.1933f   ,  -4.625f  ,  -66.2f     ,  90},    
								{  -167.6068f   ,  -4.625f  ,  -50.4f     , -90},  
								{  -141.4f      ,  -4.625f  ,  -46.60674f , 180},   
								{  -137.6068f   ,  -4.625f  ,  -32.4f     , -90},   
								{  -203.7f      ,  -4.625f  ,  -46.706f   , 180},
								{  -203.7067f   ,  -4.625f  ,  -35.4f     , -90},
								{  -187.1933f   ,  -4.625f  ,  -29.4f     ,  90},
								{  -215.7067f   ,  -4.625f  ,  -20.4f     , -90},
								{  -160.1933f   ,  -4.625f  ,  -17.4f     ,  90}};
	int ATM;    
	List<Quaternion> MoufaQuartList = new List<Quaternion>();
    List<Vector3> MoufaPosList = new List<Vector3>();
    Vector3[] PosList = new Vector3[3];
    Quaternion[] QuartList = new Quaternion[3];
	[SerializeField]  private  GameEvents  events;

	public GameObject[] ATMSPR= {null,null,null};	
	public bool FirstRun = true;

	public void MazeStart() {
		List<int> numbers = new List<int>();
		for (int i = 0; i <= 9; i++) {
			numbers.Add(i);
		}
		System.Random rand = new System.Random();
		
		for (int i = 0; i < 3; i++) {
			ATM = numbers[rand.Next(numbers.Count)];
			numbers.Remove(ATM);
			SpawnATM(ATM, ATMSPR[i]);
		}
		for (int i = 0; i < 7; i++) {
			ATM = numbers[rand.Next(numbers.Count)];
			numbers.Remove(ATM);
			SpawnATM(ATM, ATMPrmoufa);
		}	
		//CaptureData();
	}

	public void SpawnATM(int ATM, GameObject pr) {
            UnityEngine.Vector3 ATMPos = new UnityEngine.Vector3(MazePos[ATM,0], MazePos[ATM,1], MazePos[ATM,2]);
			UnityEngine.Quaternion CoinQ = UnityEngine.Quaternion.AngleAxis(MazePos[ATM,3], Vector3.up);
            Instantiate(pr, ATMPos, CoinQ);
    }
	//List<GameObject> ATMList = new List<GameObject>();
    /*public void CaptureData()
    {
        MoufaQuartList .Clear();
        MoufaPosList.Clear();
		//ATMList.Clear();

        GameObject[] mazeMoufas = GameObject.FindGameObjectsWithTag("MazeMoufa");
        foreach (GameObject mazeMoufa in mazeMoufas)
        {
            MoufaPosList.Add(mazeMoufa.transform.position);
            MoufaQuartList .Add(mazeMoufa.transform.rotation);
			//ATMList.Add(mazeMoufa);
        }
        
            GameObject ATM = GameObject.FindGameObjectWithTag("MazeQuiz1");
            PosList[0] = ATM.transform.position;
            QuartList[0] = ATM.transform.rotation;
			Debug.Log(PosList[0] + " " + QuartList[0]);	
			GameObject ATM2 = GameObject.FindGameObjectWithTag("MazeQuiz2");
			PosList[1] = ATM2.transform.position;
			QuartList[1] = ATM2.transform.rotation;
			Debug.Log(PosList[1] + " " + QuartList[1]);
			GameObject ATM3 = GameObject.FindGameObjectWithTag("MazeQuiz3");
			PosList[2] = ATM3.transform.position;
			QuartList[2] = ATM3.transform.rotation;
			Debug.Log(PosList[2] + " " + QuartList[2]);
			//ATMList.Add(ATM);
        
		events.pendingspawn = true;

    }
	/*public void RespawnATMs(){
		for (int i = 0; i < 3; i++)
		{
			Debug.Log(PosList[i] + " " + QuartList[i]);
			Instantiate(ATMSPR[i], PosList[i], QuartList[i]);
		}
		Debug.Log(MoufaPosList.Count);
		for (int i = 0; i < MoufaPosList.Count; i++)
		{
			Instantiate(ATMPrmoufa, MoufaPosList[i], MoufaQuartList[i]);
		}
		
	}*/
    public void Start(){   
		//Debug.Log("Pass1");
        if (events.pendingspawn){
			MazeStart();
			//RespawnATMs();
			//Debug.Log("Pass");
			//events.pendingspawn = false;
		}
    }



}
