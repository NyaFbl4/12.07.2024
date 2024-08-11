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

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders, IGameRepository gameRepository)
        {
            _saveLoaders = saveLoaders;
            _gameRepository = gameRepository as GameRepository;
        }
        
        [Button]
        public void SaveGame()
        {
            //var sceneInstaller = FindObjectOfType<SceneInstaller>();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame( _gameRepository);
            }
            
            _gameRepository.SaveState();
        }
            
        [Button]
        public void LoadGame()
        {
            _gameRepository.LoadState();
            
            //var sceneInstaller = FindObjectOfType<SceneInstaller>();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame( _gameRepository);
            }
        }
    }
}