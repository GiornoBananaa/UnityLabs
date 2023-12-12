using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        private PlayerMovement _playerMovement;
        
        public void Construct(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }

        private void Update()
        {
            ReadMovementInput();
        }

        private void ReadMovementInput()
        {
            float x = Input.GetAxis(HorizontalInput);
            float y = Input.GetAxis(VerticalInput);
            
            _playerMovement.Move(x,y);
        }
    }
}
