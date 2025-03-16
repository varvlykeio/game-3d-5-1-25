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
	public float[,] MazePos =  {   {  -234f        ,  -4.625f  ,  -66.32f    , 0},    
                                   {  -187.1933f   ,  -4.625f  ,  -66.2f     , 0},    
                                   {  -167.6068f   ,  -4.625f  ,  -51.29f    , 0},  
                                   {  -156.94f     ,  -4.625f  ,  -51.09f    , 0},   
                                   {  -137.6068f   ,  -4.625f  ,  -33.29f    , 0},   
                                   {  -203.7f      ,  -4.625f  ,  -57.277f   , 0},
								   {  -203.7067f   ,  -4.625f  ,  -36.34f    , 0},
								   {  -187.1933f   ,  -4.625f  ,  -30.23f    , 0},
								   {  -215.7067f   ,  -4.625f  ,  -21.32f    , 0},
								   {  -160.1933f   ,  -4.625f  ,  -18.2f     , 0}};
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
            UnityEngine.Quaternion CoinQ = new UnityEngine.Quaternion(0,0,0,0);
            Instantiate(pr, ATMPos, CoinQ);
			GameObject tbr = GameObject.Find("PendingRotation");
			tbr.transform.parent.gameObject.transform.Rotate(0, MazePos[ATM,3], 0);
			Destroy(tbr);

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
