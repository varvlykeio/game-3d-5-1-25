using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameEv;

namespace Resolution{
    public class ResolutionScore : MonoBehaviour
    {
        public TextMeshProUGUI coinScore;
        public TextMeshProUGUI quizScore;
        public TextMeshProUGUI timerScore;
        public TextMeshProUGUI totalScore;
        public TextMeshProUGUI timeRemaining;
        public TextMeshProUGUI HighScore;
        public GameObject ResolutionScreen;
        public GameObject ResolutionScreenQuiz;
        public GameObject QuizScreen;
        public GameEvents events;


        public void GameEnd(){
            events.GameFinished = true;
            events.timerScore = (int)(events.rtime*events.timegravity);
            events.TScore = events.coinScore + events.quizScore + events.timerScore;
            if (events.TScore > events.HighScore)
            {
                events.HighScore = events.TScore;
            }
            UpdateUI();
            ResolutionScreenQuiz.SetActive(false);
            QuizScreen.SetActive(false);
            ResolutionScreen.SetActive(true);
        }
        void UpdateUI()
        {
            coinScore.text = "Coin Score: " + events.coinScore.ToString();
            quizScore.text = "Quiz Score: " + events.quizScore.ToString();
            timerScore.text = "Timer Score: " + events.timerScore.ToString();
            totalScore.text = "Total Score: " + events.TScore.ToString();
            HighScore.text = "High Score: " + events.HighScore.ToString();
            int minutes = Mathf.FloorToInt(events.rtime / 60);
            int seconds = Mathf.FloorToInt(events.rtime % 60); 
            timeRemaining.text = string.Format("Remaining Time: " + "{0:00}:{1:00}", minutes, seconds);
        }
    }
}
