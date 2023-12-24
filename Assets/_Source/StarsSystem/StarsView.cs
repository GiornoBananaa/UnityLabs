using Core;
using DG.Tweening;
using UnityEngine;

namespace StarsSystem
{
    public class StarsView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _starsSprite;
        [Range(0,1)][SerializeField] private float _fadeMorning;
        [Range(0,1)][SerializeField] private float _fadeDay;
        [Range(0,1)][SerializeField] private float _fadeAfternoon;
        [Range(0,1)][SerializeField] private float _fadeNight;
        [SerializeField] private float _fadeLerpDuration;

        private void OnEnable()
        {
            Stars.OnStarsChange += UpdateSky;
        }

        public void UpdateSky(DayState dayState)
        {
            switch (dayState)
            {
                case DayState.Morning:
                    SetStarsFade(_fadeMorning);
                    break;
                case DayState.Day:
                    SetStarsFade(_fadeDay);
                    break;
                case DayState.Afternoon:
                    SetStarsFade(_fadeAfternoon);
                    break;
                case DayState.Night:
                    SetStarsFade(_fadeNight);
                    break;
            }
        }

        private void SetStarsFade(float fade)
        {
            _starsSprite.DOFade(fade,_fadeLerpDuration).SetEase(Ease.Linear);
        }

        private void OnDisable()
        {
            Stars.OnStarsChange -= UpdateSky;
        }
    }
}
