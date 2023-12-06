using System;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour,IObservable
{
    private List<IObserver> _observers;
    private DayState _currDayState;
    private float _time;
    
    
    private void Awake()
    {
        _observers = new List<IObserver>();
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
        switch (_time)
        {
            case _time > 6 && _time < 12:
                    
                break;
        }
    }

    #endregion


}
