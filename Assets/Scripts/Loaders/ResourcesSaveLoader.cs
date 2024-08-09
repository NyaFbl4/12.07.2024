using System;
using GameEngine.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    [Serializable]
    public class ResourcesSaveLoader : ISaveLoader
    {
        private IGameRepository _gameRepository;
        private readonly WoodStorage _woodStorage;
        private readonly StoneStorage _stoneStorage;
        
        public ResourcesSaveLoader(WoodStorage woodStorage, StoneStorage stoneStorage, IGameRepository gameRepository)
        {
            _woodStorage = woodStorage;
            _stoneStorage = stoneStorage;
            _gameRepository = gameRepository;
            Debug.Log("Create ResourcesSaveLoader");
        }

        public void LoadGame(SceneInstaller sceneInstaller)
        {
            if (_gameRepository.TryGetData<int>(out int wood))
            {
                //var wood = PlayerPrefs.GetInt("Scripts/Resources/Wood");
                _woodStorage.SetupWood(wood);
                Debug.Log($"Загрузили дерево " + _woodStorage.Wood.Value);
            }

            if (_gameRepository.TryGetData<int>(out int stone))
            {
                //var stone = PlayerPrefs.GetInt("Scripts/Resources/Stone");
                _stoneStorage.SetupStone(stone);
                Debug.Log($"Загрузили камень " + _stoneStorage.Stone.Value);
            }
        }
        
        public void SaveGame(SceneInstaller sceneInstaller)
        {
            _gameRepository.SetData(_woodStorage.Wood.Value);
            PlayerPrefs.SetInt("Scripts/Resources/Wood", _woodStorage.Wood.Value);
            Debug.Log("Сохранили дерево " + _woodStorage.Wood.Value);
            
            _gameRepository.SetData(_stoneStorage.Stone.Value);
            PlayerPrefs.SetInt("Scripts/Resources/Stone", _stoneStorage.Stone.Value);
            Debug.Log("Сохранили камень " + _stoneStorage.Stone.Value);
        }
    }
}