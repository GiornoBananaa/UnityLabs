using System;
using NuclearSystem.Time;
using NuclearSystem.View;
using TimerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class Game
    {
        private GameObject _lossPanel;
        private GameTimer _gameTimer;
        
        public Game(GameObject lossPanel, Button lossRestartButton, GameTimer gameTimer)
        {
            _lossPanel = lossPanel;
            lossRestartButton.onClick.AddListener(Restart);
            _gameTimer = gameTimer;
            ResourceTimerService.Instance.QuitPause();
            ResourceTimerService.Instance.OnDecayTimerEnd += LoseGame;
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoseGame()
        {
            ResourceTimerService.Instance.OnDecayTimerEnd -= LoseGame;
            PauseGame();
            _lossPanel.SetActive(true);
        }

        public void PauseGame()
        {
            _gameTimer.Pause();
            ResourceTimerService.Instance.PauseAllTimers();
        }
    }
}
