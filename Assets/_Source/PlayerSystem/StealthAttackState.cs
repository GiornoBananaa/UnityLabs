using Core;
using TMPro;

namespace PlayerSystem
{
    public class StealthAttackState : AState
    {
        private Player _player;
        private TMP_Text _stateText;
        
        public StealthAttackState(Player player, TMP_Text stateText)
        {
            _stateText = stateText;
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "Stealth";
            _player.ChangeCombat<PlayerStealthCombat>();
        }
    }
}
