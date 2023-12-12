using System;
using System.Collections.Generic;
using PlayerSystem;

namespace Core
{
    public class StateMachine<T>: IStateMachine where T : AState
    {
        private Dictionary<Type, T> _states;
        private AState _currState;
        
        public StateMachine(T shootAttackState, T rangeAttackState, T stealthAttackState)
        {
            SetupStates(shootAttackState, rangeAttackState, stealthAttackState);
        }

        public StateMachine() { }

        public void SetupStates(T shootAttackState, T rangeAttackState, T stealthAttackState)
        {
            _states = new()
            {
                {typeof(ShootAttackState), shootAttackState},
                {typeof(RangeAttackState), rangeAttackState},
                {typeof(StealthAttackState), stealthAttackState}
            };

            foreach (var state in _states)
            {
                state.Value.SetOwner(this);
            }
        }
        
        public bool ChangeState<T>()
        {
            _currState?.Exit();
            if (_states.ContainsKey(typeof(T)))
            {
                _currState = _states[typeof(T)];
                _currState.Enter();
                return true;
            }

            return false;
        }
        
        public void Update() => _currState.Update();
    }
}
