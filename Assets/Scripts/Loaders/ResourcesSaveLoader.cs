using GameEngine.Installers;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class ResourcesSaveLoader : MonoBehaviour
    {
        private WoodStorage _woodStorage;
        
        [Inject]
        public void Construct(WoodStorage woodStorage)
        {
            _woodStorage = woodStorage;
        }

        public void Awake()
        {
            if (PlayerPrefs.HasKey("Scripts/Resources/Wood"))
            {
                var value = PlayerPrefs.GetInt("Scripts/Resources/Wood");
                _woodStorage.AddWood(value);
                Debug.Log($"Загрузили дерево " + value);
            }
        }
        
        [Button]
        public void Save()
        {
            
            PlayerPrefs.SetInt("Scripts/Resources/Wood", _woodStorage.Wood.Value);
            Debug.Log("Сохранили дерево " + _woodStorage.Wood.Value);
        }
    }
}