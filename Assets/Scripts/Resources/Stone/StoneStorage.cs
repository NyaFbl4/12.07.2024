using UniRx;

namespace GameEngine
{
    public class StoneStorage
    {
        public IReadOnlyReactiveProperty<int> Stone => _stone;
        private readonly ReactiveProperty<int> _stone;

        public StoneStorage(int stone)
        {
            _stone = new IntReactiveProperty(stone);
        }

        public void SetupStone(int stone)
        {
            _stone.Value = stone;
        }
        
        public void AddStone(int stone)
        {
            _stone.Value += stone;
        }

        public void SpendStone(int stone)
        {
            _stone.SetValueAndForceNotify(_stone.Value - stone);
        }
    }
}