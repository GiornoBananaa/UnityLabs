using UnityEngine;

namespace PlayerSystem
{
    public class Player
    {
        private readonly PlayerModel _model;
        private readonly PlayerHealthView _healthHealthView;
        private readonly PlayerMovement _playerMovement;
        
        public Player(PlayerModel model, PlayerMovement playerMovement, PlayerHealthView healthView)
        {
            _model = model;
            _healthHealthView = healthView;
            _playerMovement = playerMovement;
        }
        
        public void GetDamage(int damage)
        {
            _model.AddHp(damage);
            _healthHealthView.UpdateHpText(_model.HP);
        }
        
        public void MovePlayer(Vector3 destination)
        {
            _playerMovement.Move(destination);
        }
    }
}