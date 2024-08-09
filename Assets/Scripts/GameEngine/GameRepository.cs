using System.Collections.Generic;
using GameEngine.Installers;
using Newtonsoft.Json;

namespace GameEngine
{
    public class GameRepository : IGameRepository
    {
        private Dictionary<string, string> _gameState = new();
        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).ToString();

            if (_gameState.TryGetValue(key, out var jsonData))
            {
                data = JsonConvert.DeserializeObject<T>(jsonData);
                return true;
            }


            data = default;
            return false;
        }

        public void SetData<T>(T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var key = typeof(T).ToString();
            _gameState[key] = jsonData;
        }
    }
}