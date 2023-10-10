using NuclearSystem.Data;
using NuclearSystem.View;
using UnityEngine;

namespace NuclearSystem.Time
{
    public class ResourceTimeService
    {
        private static ResourceTimeService instance;
        private static ResourceTimeDataSO _resourceTimeData = Resources.Load("ResourceTimeDataSO") as ResourceTimeDataSO;
    
        public static ResourceTimeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceTimeService();
                }
    
                return instance;
            }
    
        }
    
        public bool GetProcessResourceTime(NuclearResourceType type,out float time)
        {
            if (_resourceTimeData)
            {
                foreach (var timeData in _resourceTimeData.ResourceTimeDatas)
                {
                    if (timeData.ResourceType == type)
                    {
                        time = timeData.ResourceProcessTime;
                        return true;
                    }
                }
            }
            
            time = 0;
            return false;
        }
            
        public bool GetDecayResourceTime(NuclearResourceType type,out float time)
        {
            if (_resourceTimeData)
            {
                foreach (var timeData in _resourceTimeData.ResourceTimeDatas)
                {
                    if (timeData.ResourceType == type)
                    {
                        time = timeData.ResourceDecayTime;
                        return true;
                    }
                }
            }

            time = 0;
            return false;
        }
    }
}