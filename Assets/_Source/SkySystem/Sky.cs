using System;
using Core;

namespace SkySystem
{
    public class Sky: IObserver
    {
        public static Action<DayState> OnSkyChange;

        public void Update(DayState dayState)
        {
            OnSkyChange?.Invoke(dayState);
        }
    }
}
