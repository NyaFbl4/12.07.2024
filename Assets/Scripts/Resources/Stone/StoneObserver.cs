using System;
using UniRx;

namespace GameEngine
{
    public class StoneObserver : IDisposable
    {
        private readonly ResourcesView _view;
        private readonly StoneStorage _storage;
        private readonly IDisposable _disposable;

        public StoneObserver(ResourcesView resourcesView, StoneStorage stoneStorage)
        {
            _view = resourcesView;
            _storage = stoneStorage;
            _disposable = _storage.Stone.SkipLatestValueOnSubscribe().Subscribe(OnStoneChanged);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnStoneChanged(int wood)
        {
            _view.UpdateCurrency(wood);
        }
    }
}