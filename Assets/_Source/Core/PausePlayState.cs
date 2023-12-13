using InputSystem;
using UnityEngine;

namespace Core
{
    public class PausePlayState : AState
    {
        private GameObject _pausePanel;

        public PausePlayState(GameObject pausePanel)
        {
            _pausePanel = pausePanel;
        }
        
        public override void Enter()
        {
            base.Enter();
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        
        public override void Exit()
        {
            base.Exit();
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
