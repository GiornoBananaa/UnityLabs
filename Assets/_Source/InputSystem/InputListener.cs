using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode _shootCombatStateKey;
        [SerializeField] private KeyCode _rangeCombatStateKey;
        [SerializeField] private KeyCode _stealthCombatStateKey;
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private Player _player;
        
        public void Construct(Player player)
        {
            _player = player;
        }
        
        private void Update()
        {
            ReadMovementInput();
            ReadAttackInput();
            ReadCombatChangeInput();
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
    }
}
