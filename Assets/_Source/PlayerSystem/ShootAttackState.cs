using Core;
using TMPro;

namespace PlayerSystem
{
    public class ShootAttackState : AState
    {
        private Player _player;
        private TMP_Text _stateText;
        
        public ShootAttackState(Player player, TMP_Text stateText)
        {
            _stateText = stateText;
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "GunShooting";
            _player.ChangeCombat<PlayerGunCombat>();
        }
    }
}
