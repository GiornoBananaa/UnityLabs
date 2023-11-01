using System;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        private Player _player;
        
        public void Construct(Player player)
        {
            _player = player;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(_enemyMask == (_enemyMask  | (1<<other.gameObject.layer)))
            {
                _player.GetDamage(1);
            }
        }
    }
}
