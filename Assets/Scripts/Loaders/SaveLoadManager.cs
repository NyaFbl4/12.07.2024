using GameEngine.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class SaveLoadManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public ISaveLoader[] _saveLoaders;

        private GameRepository _gameRepository;
        private DiContainer _diContainer;
        
        private SceneInstaller _sceneInstaller;
        
        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, IGameRepository gameRepository, DiContainer diContainer)
        {
            _saveLoaders = saveLoaders;
            _gameRepository = gameRepository as GameRepository;
            _diContainer = diContainer;
        }
        
        [Button]
        public void SaveGame()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_diContainer, _gameRepository);
            }
            
            _gameRepository.SaveState();
        }
            
        [Button]
        public void LoadGame()
        {
            _gameRepository.LoadState();

            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_diContainer, _gameRepository);
            }
        }
    }
}