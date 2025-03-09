using UnityEngine;


namespace GameEv{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/new GameEvents")]



    public class GameEvents : ScriptableObject {

        public delegate void    UpdateQuestionUICallback            (Question question);
        public                  UpdateQuestionUICallback            UpdateQuestionUI                = null;

        public delegate void    UpdateQuestionAnswerCallback        (AnswerData pickedAnswer);
        public                  UpdateQuestionAnswerCallback        UpdateQuestionAnswer            = null;

        public delegate void    DisplayResolutionScreenCallback     (UIManager.ResolutionScreenType type, int score);
        public                  DisplayResolutionScreenCallback     DisplayResolutionScreen         = null;

        public delegate void    ScoreUpdatedCallback();
        public                  ScoreUpdatedCallback                ScoreUpdated                    = null;

        [HideInInspector]
        public                  int                                 level                           = 1;
        public const            int                                 maxLevel                        = 1;

        [HideInInspector]
        public                  int                                 CurrentFinalScore               = 0;
        [HideInInspector]
        public                  int                                 StartupHighscore                = 0;
        public                  int                                 TotalScore                      = 0; 
        public                  int                                 currentlevel                    = 0;    
        public                  bool                                CursorLock                      = false;
        public                  bool                                FirstRun                        = true;
		public                  bool                                QuizStart                       = false;
        public                  int                                 Difficulty                      = 0;
        public                  float                               rtime                           = 600;
        public                  int                                 score                           = 0;
        public                  int                                 coinScore                       = 0;
        public                  int                                 quizScore                       = 0;
        public                  int                                 timerScore                      = 0;
        public                  int                                 TScore                          = 0;  
        public                  float                               timeRemaining                   = 0;  
        public                  float                               timegravity                     = 1f;         
        public                  bool                                isPaused                        = false;
        public                  bool                                QuizActive                      = false; 
        public                  int                                 HighScore                       = 0;
        public                  bool                                GameFinished                    = false;
        public                  bool                                MenuOpen                        = true;
        public                  float                               TotalTime                       = 0;
        public                  int                                 CoinImportance                  = 25;
        public                  bool                                triggered                       = false;
        public                  bool                                teleport                        = false;
        public                  Vector3                             playerposition                  = new Vector3(0,0,0);
        public                  bool                                Maze                            = false;
    }
}