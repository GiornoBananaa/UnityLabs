using Core;
using TMPro;

namespace PlayerSystem
{
    public class RangeAttackState : AState
    {
        private Player _player;
        private TMP_Text _stateText;
        
        public RangeAttackState(Player player, TMP_Text stateText)
        {
            _stateText = stateText;
            _player = player;
        }
        
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "RedZone";
            _player.ChangeCombat<PlayerRangeCombat>();
        }
    }
}
