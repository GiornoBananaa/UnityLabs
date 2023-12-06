using UnityEngine;

public class SkyView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Color _morningColor;
    [SerializeField] private Color _dayColor;
    [SerializeField] private Color _afternoonColor;
    [SerializeField] private Color _nightColor;

    private void OnEnable()
    {
        Sky.OnSkyChange += UpdateSky;
    }

    public void SetMorning() => SetSkyColor(_morningColor);
    public void SetDay() => SetSkyColor(_dayColor);
    public void SetAfternoon() => SetSkyColor(_afternoonColor);
    public void SetNight() => SetSkyColor(_nightColor);

    public void UpdateSky(DayState dayState)
    {
        switch (dayState)
        {
            case DayState.Morning:
                SetMorning();
                break;
            case DayState.Day:
                SetDay();
                break;
            case DayState.Afternoon:
                SetAfternoon();
                break;
            case DayState.Night:
                SetNight();
                break;
        }
    }

    private void SetSkyColor(Color color)
    {
        _camera.backgroundColor = color;
    }

    private void OnDisable()
    {
        Sky.OnSkyChange -= UpdateSky;
    }
}
