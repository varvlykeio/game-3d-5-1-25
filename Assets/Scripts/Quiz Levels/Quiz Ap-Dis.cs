using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MyVars;
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
		void Update () {
			GameObject tempObj1 = GameObject.Find("ATM1(Clone)");
			scriptInstance1 = tempObj1.GetComponent<QuizCols>();
			GameObject tempObj2 = GameObject.Find("ATM2(Clone)");
			scriptInstance2 = tempObj2.GetComponent<QuizCols>();
			GameObject tempObj3 = GameObject.Find("ATM3(Clone)");
			scriptInstance3 = tempObj3.GetComponent<QuizCols>();
				

			levelcheck1 = scriptInstance1.pusher;
			levelcheck2 = scriptInstance2.pusher;
			levelcheck3 = scriptInstance3.pusher;


	
			if (levelcheck1 == true || levelcheck2 == true || levelcheck3 == true) {


				Content.SetActive(true);
				Resolution.SetActive(true);
				events.FirstRun = true;
				
					
			}
		}
	}
}