using Core;

namespace PlayerSystem
{
    public class ShootAttackState : AState
    {
        private Player _player;
        
        public ShootAttackState(Player player)
        {
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _player.ChangeCombat<PlayerGunCombat>();
        }
    }
}
