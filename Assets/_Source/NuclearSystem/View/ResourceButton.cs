using NuclearSystem.Data;
using NuclearSystem.Time;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NuclearSystem.View
{
    [RequireComponent(typeof(Image))]
    public class ResourceButton : MonoBehaviour
    {
        [SerializeField] private NuclearResourceType resourceType;
        [SerializeField] private TMP_Text timeText;
        
        private Image _icon;
        private Button _button;
        private Sprite _processSprite;
        private Sprite _decaySprite;
        private bool _isDecoy;
        
        private void Start()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(() => ResourceTimerService.Instance.StopDecay(this));
            
            if (ResourceViewService.Instance.GetProcessResourceIcon(resourceType, out Sprite processIcon))
            {
                _processSprite = processIcon;
                _icon.sprite = processIcon;
            }
            if (ResourceViewService.Instance.GetDecayResourceIcon(resourceType, out Sprite deacyIcon))
            {
                _decaySprite = deacyIcon;
            }

            float timeDecoy = 0;
            float timeProcess = 0;
            if (ResourceTimeService.Instance.GetDecayResourceTime(resourceType, out float deacyTime))
            {
                timeDecoy = deacyTime;
            }
            if (ResourceTimeService.Instance.GetProcessResourceTime(resourceType, out float processTime))
            {
                timeProcess = processTime;
            }
            
            ResourceTimerService.Instance.AddTimer(this,timeProcess, timeDecoy,timeText);
            
            _isDecoy = false;
            timeText.text = "0";
            _button.image.raycastTarget = false;
        }

        private void Update()
        {
            ResourceTimerService.Instance.UpdateTimer(this);
        }

        public void StartDecay()
        {
            _icon.sprite = _decaySprite;
            _button.image.raycastTarget = true;
        }
        
        public void StopDecay()
        {
            _icon.sprite = _processSprite;
            _button.image.raycastTarget = false;
        }
    }
}
