using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameEngine
{
    public class Helper : MonoBehaviour
    {
       // [SerializeField] private long _current;
        [SerializeField] private int _current;
        private WoodStorage _woodStorage;
        private StoneStorage _stoneStorage;

        [Inject]
        public void Construct(WoodStorage woodStorage, StoneStorage stoneStorage)
        {
            _woodStorage = woodStorage;
            _stoneStorage = stoneStorage;
        }
        
        [Button]
        public void AddWood()
        {
            _woodStorage.AddWood(_current);
        }

        [Button]
        public void AddStone()
        {
            _stoneStorage.AddStone(_current);    
        }
    }
}