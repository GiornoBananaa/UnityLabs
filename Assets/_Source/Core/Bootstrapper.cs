using System;
using System.Collections.Generic;
using InputSystem;
using PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private GameObject _redZone;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Button _pauseButton;
        private Player _player;
        private PlayerMovement _playerMovement;
        private PlayerCombat _playerCombat;
        private StateMachine<AState> _playerCombatStateMachine;
        private StateMachine<AState> _gameStateMachine;
        
        private void Awake()
        {
            Dictionary<Type, PlayerCombat> playerCombats = new Dictionary<Type, PlayerCombat>()
            {
                {typeof(PlayerGunCombat), new PlayerGunCombat(_bulletPrefab,_firePoint)},
                {typeof(PlayerRangeCombat), new PlayerRangeCombat(_redZone)},
                {typeof(PlayerStealthCombat), new PlayerStealthCombat(_spriteRenderer)}
            };
            _playerCombatStateMachine = new StateMachine<AState>();
            _playerMovement = new PlayerMovement(_playerSpeed,_playerTransform);
            _player = new Player(_playerMovement,_playerCombat, _playerCombatStateMachine,playerCombats);
            _playerCombatStateMachine.SetupStates(
                new ShootAttackState(_player),
                new RangeAttackState(_player),
                new StealthAttackState(_player));
            _gameStateMachine = new StateMachine<AState>(new GamePlayState(_inputListener),
                new PausePlayState(_pauseButton.gameObject),
                new FinalPlayState(_player));
            _inputListener.Construct(_player,_gameStateMachine);
            _player.ChangeCombatState<ShootAttackState>();
            _pauseButton.onClick.AddListener(()=>_gameStateMachine.ChangeState<GamePlayState>());
            _gameStateMachine.ChangeState<GamePlayState>();
            
        }

        private void Update()
        {
            _playerCombatStateMachine.Update();
        }
    }
}
