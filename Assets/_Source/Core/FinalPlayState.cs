using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class FinalPlayState : AState
    {
        private readonly Player _player;

        public FinalPlayState(Player player)
        {
            _player = player;
        } 
        
        public override void Enter()
        {
            base.Enter();
            _player.DisarmPlayer();
        }
    }
}
