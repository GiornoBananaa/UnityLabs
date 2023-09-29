using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourceBank
    {
        private static ResourceBank _instance;
        public static ResourceBank Instance => _instance ??= new ResourceBank();
        
        private Dictionary<ResourceType, Resource> _resources;
        
        public ResourceBank()
        {
            _resources = new Dictionary<ResourceType, Resource>();
        }
        
        public void AddResource(ResourceType type, int quantity)
        {
            if (_resources.TryGetValue(type, out Resource resource))
            {
                resource.Quantity += quantity;
            }
            else
            {
                _resources.Add(type, new Resource(type,quantity)); 
            }
        }
        
        public int GetQuantity(ResourceType type)
        {
            int quantity = 0;
            if (_resources.TryGetValue(type, out Resource resource))
            {
                quantity = resource.Quantity;
            }

            return quantity;
        }
    }
}
