using Core;

namespace PlayerSystem
{
    public class StealthAttackState : AState
    {
        private Player _player;
        
        public StealthAttackState(Player player)
        {
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _player.ChangeCombat<PlayerStealthCombat>();
        }
    }
}
