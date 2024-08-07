using UniRx;

namespace GameEngine
{
    public class WoodStorage
    {
        public IReadOnlyReactiveProperty<int> Wood => _wood;

        private readonly ReactiveProperty<int> _wood;

        public WoodStorage(int wood)
        {
            _wood = new IntReactiveProperty(wood);
        }

        public void AddWood(int wood)
        {
            _wood.Value += wood;
        }

        public void SpendWood(int wood)
        {
            _wood.SetValueAndForceNotify(_wood.Value - wood);
        }
    }
}