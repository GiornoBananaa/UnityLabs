using Core;
using DG.Tweening;
using UnityEngine;

namespace SunSystem
{
    public class SunView : MonoBehaviour
    {
        [SerializeField] private Transform _sunPivotTransform;
        [SerializeField] private float _morningRotation;
        [SerializeField] private float _dayRotation;
        [SerializeField] private float _afternoonRotation;
        [SerializeField] private float _nightRotation;
        [SerializeField] private float _rotationDuration;

        private void OnEnable()
        {
            Sun.OnSunChange += UpdateSky;
        }

        public void UpdateSky(DayState dayState)
        {
            switch (dayState)
            {
                case DayState.Morning:
                    SetSunRotation(_morningRotation);
                    break;
                case DayState.Day:
                    SetSunRotation(_dayRotation);
                    break;
                case DayState.Afternoon:
                    SetSunRotation(_afternoonRotation);
                    break;
                case DayState.Night:
                    SetSunRotation(_nightRotation);
                    break;
            }
        }

        private void SetSunRotation(float rotation)
        {
            var sunRotation = _sunPivotTransform.rotation;
            _sunPivotTransform.DORotate(
                new Vector3(sunRotation.x,sunRotation.y,rotation),
                _rotationDuration).SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            Sun.OnSunChange -= UpdateSky;
        }
    }
}
