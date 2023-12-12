using Core;

namespace PlayerSystem
{
    public class RangeAttackState : AState
    {
        private Player _player;
        
        public RangeAttackState(Player player)
        {
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _player.ChangeCombat<PlayerRangeCombat>();
        }
    }
}
