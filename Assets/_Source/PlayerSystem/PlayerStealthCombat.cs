using UnityEngine;

namespace PlayerSystem
{
    public class PlayerStealthCombat: PlayerCombat
    {
        private const float SPRITE_STEALTH_TRANSPARANCY = 0.3f;
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
            _spriteRenderer.color = new Color(color.r,color.g,color.b, _stealthModeOn?SPRITE_STEALTH_TRANSPARANCY:1);
        }
        
        public override void DisarmPlayer()
        {
            _spriteRenderer.color = Color.green;
        }
    }
}