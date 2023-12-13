using InputSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class PausePlayState : AState
    {
        private readonly TMP_Text _stateText;
        
        public PausePlayState(TMP_Text stateText)
        {
            _stateText = stateText;
        }
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "Pause";
            Time.timeScale = 0;
        }
        
        public override void Exit()
        {
            base.Exit();
            Time.timeScale = 1;
        }
    }
}
