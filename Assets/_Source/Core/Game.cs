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
        private ResourceButton[] _recourceButtons;
        
        public Game(GameObject lossPanel, Button lossRestartButton, ResourceButton[] recourceButtons,GameTimer gameTimer)
        {
            _lossPanel = lossPanel;
            lossRestartButton.onClick.AddListener(Restart);
            _gameTimer = gameTimer;
            _recourceButtons = recourceButtons;
        }
        
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoseGame()
        {
            PauseGame();
            _lossPanel.SetActive(true);
        }

        public void PauseGame()
        {
            _gameTimer.Pause();
            foreach (var buttons in _recourceButtons)
            {
                buttons.PauseTimer();
            }
        }
    }
}
