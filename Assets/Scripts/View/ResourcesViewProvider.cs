using UnityEngine;

namespace GameEngine
{
    public class ResourcesViewProvider : MonoBehaviour
    {
        [SerializeField] private ResourcesView _woodView;
        [SerializeField] private ResourcesView _stoneView;

        public ResourcesView WoodView => _woodView;
        public ResourcesView StoneView => _stoneView;
    }
}