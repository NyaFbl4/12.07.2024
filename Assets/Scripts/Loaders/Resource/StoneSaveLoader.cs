using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public class StoneSaveLoader : SaveLoader<StoneStorage, StoneData>
    {
        protected override StoneData ConvertToData(StoneStorage service)
        {
            Debug.Log($"Convert Stone to data = {service.Stone}");
            return new StoneData()
            {
                Stone = service.Stone.Value
            };
        }

        protected override void SetupData(StoneStorage service, StoneData data)
        {
            service.SetupStone(data.Stone);
            Debug.Log($"Setup Stone data = {service.Stone}");
        }
    }
}