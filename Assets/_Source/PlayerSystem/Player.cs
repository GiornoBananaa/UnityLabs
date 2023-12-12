using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace PlayerSystem
{
    public class Player
    {
        private PlayerMovement _playerMovement;
        private PlayerCombat _playerCombat;
        private IStateMachine _combatStateMachine;
        
        private Dictionary<Type, PlayerCombat> _states;
        
        public Player(PlayerMovement playerMovement, PlayerCombat playerCombat, IStateMachine combatStateMachine, Dictionary<Type, PlayerCombat> states)
        {
            _playerMovement = playerMovement;
            _playerCombat = playerCombat;
            _combatStateMachine = combatStateMachine;
            _states = states;
        }

        public void ChangeCombat<T>() where T: PlayerCombat
        {
            _playerCombat = _states[typeof(T)];
        }

        public void ChangeCombatState<T>() where T: AState
        {
            _combatStateMachine.ChangeState<T>();
        }

        public void Move(float x, float y)
        {
            _playerMovement.Move(x,y);
        }
        
        public void Attack()
        {
            _playerCombat.Attack();
        }
    }
}
