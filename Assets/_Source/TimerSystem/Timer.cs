using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace TimerSystem
{
    public class Timer : MonoBehaviour,IObservable
    {
        [SerializeField] private float _dayPartTime;
        private List<IObserver> _observers;
        private DayState _currDayState;
        private float _time;
    
        private void Awake()
        {
            _observers = new List<IObserver>();
        }

        private void Start()
        {
            SetDayState(DayState.Morning);
            _time = _dayPartTime;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            CheckTime();
        }
    
        #region Observable
    
        public bool RegisterObserver(IObserver observer)
        {
            bool success = false;
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                success = true;
            }
            return success;
        }

        public bool RemoveObserver(IObserver observer)
        {
            bool success = false;
            if (!_observers.Contains(observer))
            {
                _observers.Remove(observer);
                success = true;
            }
            return success;
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_currDayState);
            }
        }
    
        #endregion

        #region Timer

        private void CheckTime()
        {
            switch (_currDayState)
            {
                case DayState.Night:
                    if (_time >= _dayPartTime)
                    {
                        SetDayState(DayState.Morning);
                    }
                    break;
                case DayState.Morning:
                    if (_time >= _dayPartTime*2)
                    {
                        SetDayState(DayState.Day);
                    }
                    break;
                case DayState.Day:
                    if (_time >= _dayPartTime*3)
                    {
                        SetDayState(DayState.Afternoon);
                    }
                    break;
                case DayState.Afternoon:
                    if (_time >= _dayPartTime*4)
                    {
                        SetDayState(DayState.Night);
                    }
                    break;
            }
        }
    
        private void SetDayState(DayState dayState)
        {
            _currDayState = dayState;
            if (dayState == DayState.Night)
                _time = 0;
            Notify();
        }
    
        #endregion
    }
}
