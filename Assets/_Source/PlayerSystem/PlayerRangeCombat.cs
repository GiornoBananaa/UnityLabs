using UnityEngine;

namespace PlayerSystem
{
    public class PlayerRangeCombat: PlayerCombat
    {
        private GameObject _redZone;
        
        public PlayerRangeCombat(GameObject redZone)
        {
            _redZone = redZone;
        }
        
        public override void Attack()
        {
            _redZone.SetActive(!_redZone.activeSelf);
        }

        public override void DisarmPlayer()
        {
            _redZone.SetActive(false);
        }
    }
}