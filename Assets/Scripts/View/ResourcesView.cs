using UnityEngine;
using TMPro;

namespace GameEngine
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _resourceText;
        private long _lastResource;
        
        public void SetupCurrency(long resource)
        {
            Setter(resource);
            _lastResource = resource;
        }

        public void UpdateCurrency(long resource)
        {
            _lastResource = resource;
            Setter(_lastResource);
        }

        private void Setter(long value)
        {
            _resourceText.text = value.ToString();
        }
    }
}