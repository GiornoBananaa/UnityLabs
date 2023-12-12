using System;
using System.Collections.Generic;
using InputSystem;
using PlayerSystem;
using UnityEngine;

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
        private Player _player;
        private PlayerMovement _playerMovement;
        private PlayerCombat _playerCombat;
        private StateMachine<AState> _playerStateMachine;
        
        private void Awake()
        {
            Dictionary<Type, PlayerCombat> states = new Dictionary<Type, PlayerCombat>()
            {
                {typeof(PlayerGunCombat), new PlayerGunCombat(_bulletPrefab,_firePoint)},
                {typeof(PlayerRangeCombat), new PlayerRangeCombat(_redZone)},
                {typeof(PlayerStealthCombat), new PlayerStealthCombat(_spriteRenderer)}
            };
            _playerStateMachine = new StateMachine<AState>();
            _playerMovement = new PlayerMovement(_playerSpeed,_playerTransform);
            _player = new Player(_playerMovement,_playerCombat, _playerStateMachine,states);
            _playerStateMachine.SetupStates(
                new ShootAttackState(_player),
                new RangeAttackState(_player),
                new StealthAttackState(_player));
            _inputListener.Construct(_player);
            _player.ChangeCombatState<ShootAttackState>();
        }

        private void Update()
        {
            _playerStateMachine.Update();
        }
    }
}
