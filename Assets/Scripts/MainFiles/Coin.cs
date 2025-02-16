using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CC;
using UnityEngine.UI;
using GameEv;


namespace CoinsNS{
    public class Coin : MonoBehaviour{  

        ControlCenter coins = null;
        [SerializeField]    GameEvents          events                  = null;

        public void OnTriggerEnter(){
            GameObject tempObj = GameObject.Find("Control Center");
            coins = tempObj.GetComponent<ControlCenter>();
            events.TotalScore += events.CoinImportance;
            events.coinScore += events.CoinImportance;
            Destroy(gameObject);
        
            

        }
    }
}   
