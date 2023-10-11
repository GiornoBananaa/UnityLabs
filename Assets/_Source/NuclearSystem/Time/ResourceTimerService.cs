using System;
using System.Collections.Generic;
using System.Globalization;
using Core;
using NuclearSystem.View;
using TMPro;

namespace NuclearSystem.Time
{
    public class ResourceTimerService
    {
        public Action OnDecayTimerEnd;
        
        private static ResourceTimerService instance;
        private Dictionary<ResourceButton, ResourceTimerData> _resourceTimerDatas = new Dictionary<ResourceButton, ResourceTimerData>();
        private bool _isPause = false;
        
        public static ResourceTimerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceTimerService();
                }

                return instance;
            }
        }
        
        public void UpdateTimer(ResourceButton button)
        {
            if (_isPause) return;
            
            ResourceTimerData timer = _resourceTimerDatas[button];
            timer.TimeRemained -= UnityEngine.Time.deltaTime;
            
            timer.TimeText.text = timer.TimeRemained.ToString("F2",CultureInfo.InvariantCulture);
            
            if (timer.TimeRemained > 0) return;
            
            if (timer.IsDecay)
            {
                OnDecayTimerEnd.Invoke();
            }
            else
            {
                timer.TimeRemained = timer.ResourceDecayTime;
                timer.IsDecay = true;
                button.StartDecay();
            }
        }
        public void StopDecay(ResourceButton button)
        {
            ResourceTimerData timer = _resourceTimerDatas[button];
            timer.TimeRemained = timer.ResourceProcessTime;
            timer.IsDecay = false;
            button.StopDecay();
        }
        
        public void AddTimer(ResourceButton button, float resourceProcessTime, float resourceDecayTime, TMP_Text timeText)
        {
            _resourceTimerDatas.Add(button,new ResourceTimerData(resourceProcessTime,resourceDecayTime,timeText));
        }

        public void PauseAllTimers()
        {
            _isPause = true;
        }
        
        public void QuitPause()
        {
            _isPause = false;
        }
    }

    public class ResourceTimerData
    {
        public float TimeRemained;
        public bool IsDecay;
        public float ResourceProcessTime { get; private set; }
        public float ResourceDecayTime { get; private set; }
        public TMP_Text TimeText { get; private set; }

        public ResourceTimerData(float resourceProcessTime, float resourceDecayTime, TMP_Text timeText)
        {
            ResourceProcessTime = resourceProcessTime;
            TimeRemained = ResourceProcessTime;
            ResourceDecayTime = resourceDecayTime;
            TimeText = timeText;
            IsDecay = false;
        }
    }
}
