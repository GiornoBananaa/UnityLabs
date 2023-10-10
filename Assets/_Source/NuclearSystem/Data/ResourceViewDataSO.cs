using System;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearSystem.Data
{
    [CreateAssetMenu(menuName = "SO/New Resource View Data", fileName = "ResourceViewDataSO")]
    public class ResourceViewDataSO : ScriptableObject
    {
        [field: SerializeField] public List<ResourceViewData> ResourceViewDatas{ get; private set; }
    }
    
    [Serializable]
    public class ResourceViewData
    {
        [field: SerializeField] public NuclearResourceType ResourceType { get; private set; }
        [field: SerializeField] public Sprite ResourceProcessIcon { get; private set; }
        [field: SerializeField] public Sprite ResourceDecayIcon { get; private set; }
    }
}
