using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using Core;
using NuclearSystem.Data;
using NuclearSystem.View;
using TMPro;
using UnityEngine;

namespace NuclearSystem.Time
{
    public class ResourceTimerService
    {
        private static ResourceTimerService instance;
        
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
        
        private Dictionary<ResourceButton, ResourceTimerData> _resourceTimerDatas = new Dictionary<ResourceButton, ResourceTimerData>();
        private Game _game;
        private bool _isPause;

        public void Construct(Game game)
        {
            _game = game;
            _isPause = false;
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
                _game.LoseGame();
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
