using UnityEngine;

namespace GameEngine
{
    public class ResourcesViewProvider : MonoBehaviour
    {
        [SerializeField] private ResourcesView _woodView;
        [SerializeField] private ResourcesView _stoneView;

        public ResourcesView GemView => _woodView;
        public ResourcesView MoneyView => _stoneView;
    }
}