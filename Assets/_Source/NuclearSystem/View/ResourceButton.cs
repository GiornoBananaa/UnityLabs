using System.Globalization;
using Core;
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
        
        private Game _game;
        private Image _icon;
        private Button _button;
        private Sprite _processSprite;
        private Sprite _decaySprite;
        private float _timeDecoy;
        private float _timeProcess;
        private float _timeRemained;
        private bool _isDecoy;
        private bool _isPause;

        public void Construct(Game game)
        {
            _game = game;
        }
        
        private void Start()
        {
            _icon = GetComponent<Image>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(CoolRecource);
            
            if (ResourceViewService.Instance.GetProcessResourceIcon(resourceType, out Sprite processIcon))
            {
                _processSprite = processIcon;
                _icon.sprite = processIcon;
            }
            if (ResourceViewService.Instance.GetDecayResourceIcon(resourceType, out Sprite deacyIcon))
            {
                _decaySprite = deacyIcon;
            }
            if (ResourceTimeService.Instance.GetDecayResourceTime(resourceType, out float deacyTime))
            {
                _timeDecoy = deacyTime;
            }
            if (ResourceTimeService.Instance.GetProcessResourceTime(resourceType, out float processTime))
            {
                _timeProcess = processTime;
                _timeRemained = processTime;
            }

            _isDecoy = false;
            _isPause = false;
            timeText.text = "0";
        }

        private void Update()
        {
            UpdateTime();
        }

        public void PauseTimer()
        {
            _isPause = true;
        }
        
        private void CoolRecource()
        {
            if (_isDecoy)
            {
                _isDecoy = false;
                _timeRemained = _timeProcess;
                _icon.sprite = _processSprite;
            }
        }
        
        private void UpdateTime()
        {
            if(_isPause) return;
            
            _timeRemained -= UnityEngine.Time.deltaTime;
            
            timeText.text = _timeRemained.ToString("F2",CultureInfo.InvariantCulture);
            
            if (_timeRemained > 0) return;
            
            if (_isDecoy)
            {
                _game.LoseGame();
            }
            else
            {
                _isDecoy = true;
                _timeRemained = _timeDecoy;
                _icon.sprite = _decaySprite;
            }
        }
    }
}
