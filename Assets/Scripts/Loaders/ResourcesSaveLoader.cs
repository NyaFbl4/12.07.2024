using GameEngine.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class ResourcesSaveLoader : ISaveLoader
    {
        private readonly WoodStorage _woodStorage;
        
        public ResourcesSaveLoader(WoodStorage woodStorage)
        {
            _woodStorage = woodStorage;
            Debug.Log("Create");
        }

        public void LoadGame(SceneInstaller sceneInstaller)
        {
            if (PlayerPrefs.HasKey("Scripts/Resources/Wood"))
            {
                var value = PlayerPrefs.GetInt("Scripts/Resources/Wood");
                _woodStorage.SetupWood(value);
                Debug.Log($"Загрузили дерево " + _woodStorage.Wood.Value);
            }
        }
        
        public void SaveGame(SceneInstaller sceneInstaller)
        {
            //var woodStorage = sceneInstaller.GetComponent<WoodStorage>();
            PlayerPrefs.SetInt("Scripts/Resources/Wood", _woodStorage.Wood.Value);
            Debug.Log("Сохранили дерево " + _woodStorage.Wood.Value);
        }
    }
}