using System;
using UniRx;

namespace GameEngine
{
    public class WoodObserver : IDisposable
    {
        private readonly ResourcesView _view;
        private readonly WoodStorage _storage;
        private readonly IDisposable _disposable;

        public WoodObserver(ResourcesView resourcesView, WoodStorage woodStorage)
        {
            _view = resourcesView;
            _storage = woodStorage;
            _disposable = _storage.Wood.SkipLatestValueOnSubscribe().Subscribe(OnWoodChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnWoodChanged(long wood)
        {
            _view.UpdateCurrency(wood);
        }
    }
}