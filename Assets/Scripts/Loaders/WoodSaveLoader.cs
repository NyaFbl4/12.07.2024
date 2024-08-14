using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class WoodSaveLoader : SaveLoader<WoodStorage, WoodData>
    {
        protected override WoodData ConvertToData(WoodStorage service)
        {
            Debug.Log($"Convert Wood to data = {service.Wood}");
            
            return new WoodData()
            {
                Wood = service.Wood.Value
            };
        }

        protected override void SetupData(WoodStorage service, WoodData data)
        {
            service.SetupWood(data.Wood);
            Debug.Log($"Setup Wood data = {service.Wood}");
        }
    }
}