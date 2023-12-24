using System;
using Core;

namespace SunSystem
{
    public class Sun : IObserver
    {
        public static Action<DayState> OnSunChange;

        public void Update(DayState dayState)
        {
            OnSunChange?.Invoke(dayState);
        }
    }
}
