using System;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private InputListener _inputListener;
        private IStateMachine _playerStateMachine;

        private void Awake()
        {
            _inputListener.Construct(_playerMovement);
            _playerStateMachine = new StateMachine<AState>(new ShootAttackState());
        }

        private void Update()
        {
            _playerStateMachine.Update();
        }
    }
}
