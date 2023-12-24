using System;
using Core;

namespace StarsSystem
{
    public class Stars : IObserver
    {
        public static Action<DayState> OnStarsChange;

        public void Update(DayState dayState)
        {
            OnStarsChange?.Invoke(dayState);
        }
    }
}
