using UnityEngine;

namespace PlayerSystem
{
    public class PlayerInvoker
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerCombat _playerCombat;
        private readonly Player _player;

        public PlayerInvoker(Player player)
        {
            _player = player;
            _playerMovement = new PlayerMovement();
            _playerCombat = new PlayerCombat();
        }

        public void Move(Vector3 moveDirection)
        {
            _playerMovement.Move(_player.Rb, _player.MovementSpeed, moveDirection);
        }
       
        public void Jump()
        {
            _playerMovement.Jump(_player.Rb, _player.JumpForce);
        }
       
        public void Rotate(Vector3 lookPoint)
        {
            _playerMovement.Rotate(_player.Rb, _player.RotationSpeed ,lookPoint);
        }
        
        public void Shoot()
        {
            _playerCombat.Shoot(_player.FirePoint, _player.BulletPrefab);
        }
    }
}
