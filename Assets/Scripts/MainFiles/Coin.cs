using UnityEngine;
using CC;
using GameEv;

namespace CoinsNS
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private ControlCenter coins = null;
        [SerializeField] private GameEvents events = null;
        public bool MazeCoin ;

        private void Start()
        {
            GameObject tempObj = GameObject.Find("Control Center");
            if (tempObj != null)
            {
                coins = tempObj.GetComponent<ControlCenter>();
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") ){
                events.TotalScore += events.CoinImportance;
                events.coinScore += events.CoinImportance;
                Destroy(gameObject);
            }
            else{
                if(MazeCoin){
                    coins.SpawnCoinsLabyrinth();
                }
                else
                {
                    coins.SpawnCoin();
                }
                Destroy(gameObject); 
            }

        }
    }
}