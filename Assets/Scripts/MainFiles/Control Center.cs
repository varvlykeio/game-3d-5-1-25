using UnityEngine;
using QuizCol;
using Doors;
using System.Diagnostics;
using System.Numerics;
using GameEv;
using UnityEditor;
using UnityEngine.UI;
using TMPro;





namespace CC{
    public class ControlCenter : MonoBehaviour{
        
        public GameObject SMenu;
        public GameObject MCanvas;
        public GameObject Player;
        public TMP_InputField TimeImp;
        public TMP_InputField TTime;
        public TMP_InputField CoinsScore;
        public TMP_InputField MazeCoins;
        public TMP_InputField Coins;
        public bool diadromos = true; // Checks if the player has entered a diadromos level to spawn the coins
        public bool changelevel = false; // Checks whether the level has changed to spawn Question machines. 
        public int level;
        public int levelch = -1;
        public int Question;
        [SerializeField]   public  GameEvents          events                  = null;



        public GameObject[] QuestionList = new GameObject[3];

                                // CoinR[level , x/y/z....]                    v-int-v
                                //     x1  ,   x2  ,    y   ,   z1  ,  z2  ,   ammount 
        public float[,] CoinR =  { {  -202f  ,  -228f  ,  0.5f  ,  63f  , 10f  ,     10     },    //Level 0
                                   {   -137.6336f   ,   -238.2793f   ,   -4    ,  -10.35214f    ,  -66   ,     100     },    //Level 1 -   Math      }
                                   {   0   ,   0   ,   0    ,   0    ,  0   ,     0     },    //Level 2 -  Coding     |
                                   {   0   ,   0   ,   0    ,   0    ,  0   ,     0     },    //Level 3 - History     |  Coordinates to 
                                   {   0   ,   0   ,   0    ,   0    ,  0   ,     0     },    //Level 4 - Language    |  be figured out
                                   {   0   ,   0   ,   0    ,   0    ,  0   ,     0     }, }; //Level 5 - Geometry    }
 

                                  //                                   QuestionR[ Question , level , x/y/z ]
                                  //              Level 1              ,            Level 2               ,      Level 3     ,      Level 4     ,      Level 5
                                  //        x    ,   y   ,    z              x      ,   y    ,    z             x , y , z          x , y , z          x , y , z
        public float[,,] QuestionR ={ {    {  -82f , 0f , -12f  }      , { -241.6f ,  0.1f  ,  18.1f  }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 } },   //Question 1
                                      {    { -211.6f , 0f , 53f }      , { -78.6f  ,  0.01f , -11.57f }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 } },   //Question 2
                                      { { -800.6f , 0.01f , -15.65f }  , { -78.6f  ,  0.01f , -15.65f }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 }  ,   { 0 , 0 , 0 } } }; //Question 3
        public GameObject coin;
        [SerializeField]  private  GameObject[] walls = new GameObject[4];
        [SerializeField] private GameObject ExitMazeButton;

        /*QuizCols1 scriptInstance1 = null;
        QuizCols2 scriptInstance2 = null;
        QuizCols3 scriptInstance3 = null;*/
        //SceneChanger scriptInstance4 = null;

        public void Start(){
            CoinR[0,5] = events.coins;
            CoinR[1,5] = events.mazecoins;              
            TimeImp.text = events.timegravity.ToString();
            TTime.text = events.TotalTime.ToString();
            CoinsScore.text = events.CoinImportance.ToString();
            MazeCoins.text = events.mazecoins.ToString();
            Coins.text = events.coins.ToString();

            if (events.pendingtransport == true){
                Player.transform.position = events.playerposition;
                events.pendingtransport = false;
            }

            for (int i = 0; i < 4; i++){
                if (events.Walls[i]){
                    walls[i].SetActive(true);
                }
            }
            
            if (changelevel == true){
                UnityEngine.Debug.Log("ping");
                //for(Question = 0; Question >= 2; Question++){   SpawnQuestions(level,Question); }  s  
                //Doesn't work with the for(), for some reason...

                /*UnityEngine.Vector3  QuestionPos = new UnityEngine.Vector3(QuestionR[0,level,0],QuestionR[0,level,1],QuestionR[0,level,2]);
                UnityEngine.Quaternion QuestionQ = new UnityEngine.Quaternion(0,0,0,0);
                Instantiate(QuestionList[Question], QuestionPos, QuestionQ);
                UnityEngine.Vector3  QuestionPos2 = new UnityEngine.Vector3(QuestionR[1,level,0],QuestionR[1,level,1],QuestionR[1,level,2]);
                UnityEngine.Quaternion QuestionQ2 = new UnityEngine.Quaternion(0,0,0,0);
                Instantiate(QuestionList[1], QuestionPos2, QuestionQ2);
                UnityEngine.Vector3  QuestionPos3 = new UnityEngine.Vector3(QuestionR[2,level,0],QuestionR[2,level,1],QuestionR[2,level,2]);
                UnityEngine.Quaternion QuestionQ3= new UnityEngine.Quaternion(0,0,0,0);
                Instantiate(QuestionList[2], QuestionPos3, QuestionQ3);*/
                    

                changelevel = false;
                UnityEngine.Debug.Log("ping");
            }
            
            level = events.currentlevel;
            if( level != levelch ){

                levelch = level;
                changelevel = true;
            }


        }

        public void Update()
        {
            if (!events.MenuOpen){
                SMenu.SetActive(false);
                MCanvas.SetActive(true);
            }
            
            if(events.Maze){
                ExitMazeButton.SetActive(true);
            }
            else{
                ExitMazeButton.SetActive(false);
            }
            

     
            if( level != levelch ){

                levelch = level;
                changelevel = true;
                UnityEngine.Debug.Log("Hm " + levelch + " " + changelevel + " " + level);
            }


            #region Coins

            if (diadromos ==true){
                
                for(float i=0; i<= CoinR[level,5]-1; i++){
                    Invoke("SpawnCoin",0.5f);
                }
                for(float i=0; i<= CoinR[level+1,5]-1; i++){
                    Invoke("SpawnCoinsLabyrinth",0.5f);
                }
                diadromos= false;

            }
            #endregion Coins



            #region Questions

            #endregion Questions



            /*GameObject tempObj1 = GameObject.Find("ATM1(Clone)");
            scriptInstance1 = tempObj1.GetComponent<QuizCols1>();
            GameObject tempObj2 = GameObject.Find("ATM2(Clone)");
            scriptInstance2 = tempObj2.GetComponent<QuizCols2>();
            GameObject tempObj3 = GameObject.Find("ATM3(Clone)");
            scriptInstance3 = tempObj3.GetComponent<QuizCols3>();
            GameObject tempObj4 = GameObject.Find("Control Center");
            scriptInstance4 = tempObj4.GetComponent<SceneChanger>();*/
            
            //level = events.level;
            
    }

        public void SpawnCoin(){

            UnityEngine.Vector3 randCoinPos = new UnityEngine.Vector3(UnityEngine.Random.Range(CoinR[level,0], CoinR[level,1]), CoinR[level,2], UnityEngine.Random.Range(CoinR[level,3], CoinR[level,4]));
            UnityEngine.Quaternion CoinQ = new UnityEngine.Quaternion(0,0,0,0);
            GameObject n = Instantiate(coin, randCoinPos, CoinQ);
            n.tag = "Coin";            
        }
        public void SpawnCoinsLabyrinth(){
            UnityEngine.Vector3 randCoinPos2 = new UnityEngine.Vector3(UnityEngine.Random.Range(CoinR[level+1,0], CoinR[level+1,1]), CoinR[level+1,2], UnityEngine.Random.Range(CoinR[+1,3], CoinR[level+1,4]));
            UnityEngine.Quaternion CoinQ2 = new UnityEngine.Quaternion(0,0,0,0);
            GameObject n = Instantiate(coin, randCoinPos2, CoinQ2);
            n.GetComponent<CoinsNS.Coin>().MazeCoin = true;
        }

        public void TransportPlayer(){
            if(events.Maze == true){
                events.pendingtransport = true;
            }
            events.pendingdestroy = true;
        }

        public void OnApplicationQuit(){       
            events.TotalScore = 0;
            events.currentlevel = 0;
            events.CursorLock = false;
            events.QuizStart = false;
            //events.rtime = 600;
            events.rtime = events.TotalTime;
            events.quizScore = 0;
            events.coinScore = 0;
            events.timerScore = 0;
            events.isPaused = true;
            events.GameFinished= false;
            events.MenuOpen = true;  
            events.Maze = false;  
            events.QuizActive = false;
            events.quizScore = 0;
            events.coinScore = 0;
            events.timerScore = 0;
        }

       
    }
}

