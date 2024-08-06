using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class Helper : MonoBehaviour
    {
        [SerializeField] private long _current;
        private WoodStorage _woodStorage;

        [Inject]
        public void Construct(WoodStorage woodStorage)
        {
            _woodStorage = woodStorage;
        }
        
        [Button]
        public void AddWood()
        {
            _woodStorage.AddWood(_current);
        }

        [Button]
        public void AddStone()
        {
            
        }
    }
}