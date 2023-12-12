using UnityEngine;

namespace PlayerSystem
{
    public class PlayerStealthCombat: PlayerCombat
    {
        private SpriteRenderer _spriteRenderer;
        private bool _stealthModeOn;
        
        public PlayerStealthCombat(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }
        
        public override void Attack()
        {
            _stealthModeOn = !_stealthModeOn;
            var color = _spriteRenderer.color;
            _spriteRenderer.color = new Color(color.r,color.g,color.b, _stealthModeOn?0.5f:1);
        }
    }
}