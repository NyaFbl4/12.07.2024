using UniRx;

namespace GameEngine
{
    public class WoodStorage
    {
        public IReadOnlyReactiveProperty<long> Wood => _wood;

        private readonly ReactiveProperty<long> _wood;

        public WoodStorage(long wood)
        {
            _wood = new LongReactiveProperty(wood);
        }

        public void AddWood(long wood)
        {
            _wood.Value += wood;
        }

        public void SpendWood(long wood)
        {
            _wood.SetValueAndForceNotify(_wood.Value - wood);
        }
    }
}