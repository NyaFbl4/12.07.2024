using GameEngine;

namespace Assets.Scripts.Loaders
{
    public class WoodSaveLoader : SaveLoader<WoodStorage, ResourcesData>
    {
        protected override ResourcesData ConvertToData(WoodStorage service)
        {
            return new ResourcesData()
            {
                Wood = service.Wood.Value
            };
        }

        protected override void SetupData(WoodStorage service, ResourcesData data)
        {
            
        }
    }
}