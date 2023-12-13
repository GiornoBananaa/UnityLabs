using InputSystem;
using PlayerSystem;
using TMPro;
using UnityEngine;

namespace Core
{
    public class FinalPlayState : AState
    {
        private readonly Player _player;
        private readonly TMP_Text _stateText;

        public FinalPlayState(Player player, TMP_Text stateText)
        {
            _stateText = stateText;
            _player = player;
        } 
        
        public override void Enter()
        {
            base.Enter();
            _stateText.text = "Final";
            _player.DisarmPlayer();
        }
    }
}
