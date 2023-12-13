using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class GamePlayState : AState
    {
        private readonly InputListener _inputListener;

        public GamePlayState(InputListener inputListener)
        {
            _inputListener = inputListener;
        } 
        
        public override void Enter()
        {
            base.Enter();
            _inputListener.EnablePlayerInput(true);
        }
        
        public override void Exit()
        {
            base.Exit();
            _inputListener.EnablePlayerInput(false);
        }
    }
}
