using System;
using Core;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode _shootCombatStateKey;
        [SerializeField] private KeyCode _rangeCombatStateKey;
        [SerializeField] private KeyCode _stealthCombatStateKey;
        [SerializeField] private KeyCode _pauseGameStateKey;
        [SerializeField] private KeyCode _finishGameStateKey;
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private Player _player;
        private StateMachine<AState> _gameStateMachine;
        private bool _playerInputIsEnabled;
        
        public void Construct(Player player, StateMachine<AState> gameStateMachine)
        {
            _player = player;
            _gameStateMachine = gameStateMachine;
            _playerInputIsEnabled = true;
        }
        
        private void Update()
        {
            if (_playerInputIsEnabled)
            {
                ReadMovementInput();
                ReadAttackInput();
                ReadCombatChangeInput();
            }
            ReadPauseInput();
            ReadFinalInput();
        }

        public void EnablePlayerInput(bool enabled)
        {
            _playerInputIsEnabled = enabled;
        }
        
        private void ReadAttackInput()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            _player.Attack();
        }
        
        private void ReadCombatChangeInput()
        {
            if (Input.GetKeyDown(_shootCombatStateKey))
            {
                _player.ChangeCombatState<ShootAttackState>();
            }
            else if (Input.GetKeyDown(_rangeCombatStateKey))
            {
                _player.ChangeCombatState<RangeAttackState>();
            }
            else if (Input.GetKeyDown(_stealthCombatStateKey))
            {
                _player.ChangeCombatState<StealthAttackState>();
            }
        }
        
        private void ReadMovementInput()
        {
            float x = Input.GetAxis(HorizontalInput);
            float y = Input.GetAxis(VerticalInput);
            
            _player.Move(x,y);
        }
        
        private void ReadPauseInput()
        {
            if (!Input.GetKeyDown(_pauseGameStateKey)) return;
            
            if(_gameStateMachine.CurrentState == typeof(PausePlayState))
                return;
            if (_gameStateMachine.CurrentState == typeof(PausePlayState))
                _gameStateMachine.ChangeState<GamePlayState>();
            else
                _gameStateMachine.ChangeState<PausePlayState>();
        }
        
        private void ReadFinalInput()
        {
            if (!Input.GetKeyDown(_finishGameStateKey)) return;

            _gameStateMachine.ChangeState<FinalPlayState>();
        }
    }
}
