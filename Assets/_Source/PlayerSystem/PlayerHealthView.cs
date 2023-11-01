using TMPro;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hpText;
        
        public void UpdateHpText(int hp)
        {
            _hpText.text = $"Current hp: {hp}";
        }
    }
}
