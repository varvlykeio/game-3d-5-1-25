using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CC;
using QuizCol;
using StarterATM;
using GameEv;

namespace QuizVars{
	public class Quiz : MonoBehaviour {
		public GameObject Content;
		public GameObject Resolution;
		[SerializeField]    GameEvents          events                  = null;
		public bool CursorLock;
	
		public              bool                levelcheck1             = false;
		public              bool                levelcheck2             = false;
		public              bool                levelcheck3             = false;
		public              bool                levelcheck4             = false;
		public              bool                levelcheck5             = false;
		public              bool                levelcheck6             = false;
		void OnEnable() {

			Content.SetActive(false);
			Resolution.SetActive(false);
			
			events.FirstRun = true;
			CursorLock = true;
			events.TotalScore =events.TotalScore+1-1; //Εβγαζε το Unity πρόβλημα ότι δεν το χρησιμοποιούσαμε. Τώρα το χρησιμοποιούμε!
			
		}
		QuizCols scriptInstance1 = null;
		QuizCols scriptInstance2 = null;
		QuizCols scriptInstance3 = null;
		QuizCols scriptInstance4 = null;
		QuizCols scriptInstance5 = null;
		QuizCols scriptInstance6 = null;
			
		void Update () {
			GameObject tempObj1 = GameObject.Find("ATM1");
			scriptInstance1 = tempObj1.GetComponent<QuizCols>();
			GameObject tempObj2 = GameObject.Find("ATM2");
			scriptInstance2 = tempObj2.GetComponent<QuizCols>();
			GameObject tempObj3 = GameObject.Find("ATM3");
			scriptInstance3 = tempObj3.GetComponent<QuizCols>();
			if(events.Maze == true){
				GameObject tempObj4 = GameObject.Find("MazeQuiz1(Clone)");
				scriptInstance4 = tempObj4.GetComponent<QuizCols>();
				GameObject tempObj5 = GameObject.Find("MazeQuiz2(Clone)");
				scriptInstance5 = tempObj5.GetComponent<QuizCols>();
				GameObject tempObj6 = GameObject.Find("MazeQuiz3(Clone)");
				scriptInstance6 = tempObj6.GetComponent<QuizCols>();
				levelcheck4 = scriptInstance4.pusher;
				levelcheck5 = scriptInstance5.pusher;
				levelcheck6 = scriptInstance6.pusher;
			}
			
				

			levelcheck1 = scriptInstance1.pusher;
			levelcheck2 = scriptInstance2.pusher;
			levelcheck3 = scriptInstance3.pusher;
			

	
			if (levelcheck1 == true || levelcheck2 == true || levelcheck3 == true || levelcheck4 == true || levelcheck5 == true || levelcheck6 == true){


				Content.SetActive(true);
				Resolution.SetActive(true);
				events.FirstRun = true;
				
					
			}
		}
	}
}