using UniRx;

namespace GameEngine
{
    public class StoneStorage
    {
        public IReadOnlyReactiveProperty<long> Stone => _stone;
        private readonly ReactiveProperty<long> _stone;

        public StoneStorage(long stone)
        {
            _stone = new LongReactiveProperty(stone);
        }

        public void AddStone(long stone)
        {
            _stone.Value += stone;
        }

        public void SpendStone(long stone)
        {
            _stone.SetValueAndForceNotify(_stone.Value - stone);
        }
    }
}