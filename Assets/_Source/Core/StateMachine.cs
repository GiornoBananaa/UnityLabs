using System;
using System.Collections.Generic;

namespace Core
{
    public class StateMachine<T>: IStateMachine where T : AState
    {
        private Dictionary<Type, T> _states;
        private AState _currState;

        public StateMachine(T shootAttackState)
        {
            SetupStates(shootAttackState);
        }

        private void SetupStates(T shootAttackState)
        {
            _states = new()
            {
                {typeof(ShootAttackState), shootAttackState}
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

    public interface IStateMachine
    {
        bool ChangeState<T>();
        void Update();
    }
}
