using InputSystem;
using PlayerSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class GamePlayState : AState
    {
        private readonly InputListener _inputListener;
        private readonly TMP_Text _stateText;

        public GamePlayState(InputListener inputListener, TMP_Text stateText)
        {
            _stateText = stateText;
            _inputListener = inputListener;
        } 
        
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "Game";
            _inputListener.EnablePlayerInput(true);
        }
        
        public override void Exit()
        {
            base.Exit();
            _inputListener.EnablePlayerInput(false);
        }
    }
}
