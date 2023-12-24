using Core;
using DG.Tweening;
using UnityEngine;

namespace SkySystem
{
    public class SkyView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Color _morningColor;
        [SerializeField] private Color _dayColor;
        [SerializeField] private Color _afternoonColor;
        [SerializeField] private Color _nightColor;
        [SerializeField] private float _colorLerpDuration;

        private void OnEnable()
        {
            Sky.OnSkyChange += UpdateSky;
        }

        public void UpdateSky(DayState dayState)
        {
            switch (dayState)
            {
                case DayState.Morning:
                    SetSkyColor(_morningColor);
                    break;
                case DayState.Day:
                    SetSkyColor(_dayColor);
                    break;
                case DayState.Afternoon:
                    SetSkyColor(_afternoonColor);
                    break;
                case DayState.Night:
                    SetSkyColor(_nightColor);
                    break;
            }
        }

        private void SetSkyColor(Color color)
        {
            _camera.DOColor(color, _colorLerpDuration).SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            Sky.OnSkyChange -= UpdateSky;
        }
    }
}
