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


public class Maze1 : MonoBehaviour

{
	public GameObject ATMPrmoufa;
									  // MazePos[level , x/y/z....]                    v-int-v
                                  //   x,    y   ,   z  
	public float[,] MazePos =  {   {  -237.4f      ,  -4.625f  ,  -52.60674f  },    
                                   {  -187.1933f   ,  -4.625f  ,  -66.2f      },    
                                   {  -167.6068f   ,  -4.625f  ,  -50.4f      },  
                                   {  -141.4f      ,  -4.625f  ,  -46.60674f  },   
                                   {  -137.6068f   ,  -4.625f  ,  -32.4f      },   
                                   {  -203.7f      ,  -4.625f  ,  -46.706f    },
								   {  -203.7067f   ,  -4.625f  ,  -35.4f      },
								   {  -187.1933f   ,  -4.625f  ,  -29.4f      },
								   {  -215.7067f   ,  -4.625f  ,  -20.4f      },
								   {  -160.1933f   ,  -4.625f  ,  -17.4f      }, };
	int ATM;

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
	}

	public void SpawnATM(int ATM, GameObject pr) {

            UnityEngine.Vector3 ATMPos = new UnityEngine.Vector3(MazePos[ATM,0], MazePos[ATM,1], MazePos[ATM,2]);
            UnityEngine.Quaternion CoinQ = new UnityEngine.Quaternion(0,0,0,0);
            Instantiate(pr, ATMPos, CoinQ);

    }
}
