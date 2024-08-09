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

        [Inject]
        public void Construct(ISaveLoader[] saveLoaders)
        {
            _saveLoaders = saveLoaders;
        }
        
        [Button]
        public void SaveGame()
        {
            var sceneInstaller = FindObjectOfType<SceneInstaller>();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(sceneInstaller);
            }
        }
            
        [Button]
        public void LoadGame()
        {
            var sceneInstaller = FindObjectOfType<SceneInstaller>();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(sceneInstaller);
            }
        }
    }
}