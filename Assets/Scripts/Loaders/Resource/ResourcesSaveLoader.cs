using System;
using System.Collections.Generic;
using GameEngine.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    [Serializable]
    public class ResourcesSaveLoader : SaveLoader<ResourceService, ResourceContainerData>
    {
        protected override ResourceContainerData ConvertToData(ResourceService service)
        {
            var resourcesData = new List<ResourceData>();
            var resources = service.GetResources();

            foreach (var resource in resources)
            {
                var data = new ResourceData
                {
                    Id = resource.ID,
                    Amount = resource.Amount
                };
                
                resourcesData.Add(data);
            }

            var resourceContainerData = new ResourceContainerData
            {
                ResourceData = resourcesData
            };

            return resourceContainerData;
        }

        protected override void SetupData(ResourceService service, ResourceContainerData data)
        {
            
        }

        /*
        //private IGameRepository _gameRepository;
        private readonly WoodStorage _woodStorage;
        private readonly StoneStorage _stoneStorage;
        
        public ResourcesSaveLoader(WoodStorage woodStorage, StoneStorage stoneStorage)
        {
            _woodStorage = woodStorage;
            _stoneStorage = stoneStorage;
            //_gameRepository = gameRepository;
            Debug.Log("Create ResourcesSaveLoader");
        }

        
        protected override WoodData ConvertToData(WoodStorage service)
        {
            Debug.Log($"Convert to data = {service.Wood}");
            return new WoodData()
            {
               // Wood = service.Wood.Value
            };
        }

        protected override void SetupData(WoodStorage service, WoodData data)
        {
            Debug.Log($"Setup data = {service.Wood}");
            //service.SetupWood(data.Wood);
        }
        
        
        public void LoadGame (DiContainer diContainer, IGameRepository gameRepository)
        {            
            if (gameRepository.TryGetData<int>(out int stone))
            {
                //var stone = PlayerPrefs.GetInt("Scripts/Resources/Stone");
                var stoneStorage = diContainer.Resolve<StoneStorage>();
                stoneStorage.SetupStone(stone);
                Debug.Log($"Загрузили камень " + stoneStorage.Stone.Value);
            }
            
            if (gameRepository.TryGetData<int>(out int wood))
            {
                //var wood = PlayerPrefs.GetInt("Scripts/Resources/Wood");
                var woodStorage = diContainer.Resolve<WoodStorage>();
                woodStorage.SetupWood(wood);
                Debug.Log($"Загрузили дерево " + woodStorage.Wood.Value);
            }
        }
        
        public void SaveGame(DiContainer diContainer, IGameRepository gameRepository)
        {
            //var woodStorage = sceneInstaller.GetComponentsInParent().
            //var woodStorage = sceneContext.Container.ParentContainers.
            var woodStorage = diContainer.Resolve<WoodStorage>();
            var stoneStorage = diContainer.Resolve<StoneStorage>();
            
            gameRepository.SetData(woodStorage.Wood.Value);
            PlayerPrefs.SetInt("Scripts/Resources/Wood", woodStorage.Wood.Value);
            Debug.Log("Сохранили дерево " + woodStorage.Wood.Value);
            
            gameRepository.SetData(stoneStorage.Stone.Value);
            PlayerPrefs.SetInt("Scripts/Resources/Stone", stoneStorage.Stone.Value);
            Debug.Log("Сохранили камень " + stoneStorage.Stone.Value);
        }
        */
    }
}