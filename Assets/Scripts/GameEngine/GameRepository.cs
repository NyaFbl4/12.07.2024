using System.Collections.Generic;
using GameEngine.Installers;
using Newtonsoft.Json;
using UnityEngine;

namespace GameEngine
{
    public class GameRepository : IGameRepository
    {
        private const string GAME_STATE_KEY = "Game_state_key";
        private Dictionary<string, string> _gameState = new();
        public bool TryGetData<T>(out T data) {
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

        public void LoadState()
        {
            if (PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                var gameStateJson = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(gameStateJson);
            }
            else
            {
                Debug.Log("no save!");
            }
        }

        public void SaveState()
        {
            var gameStateJson = JsonConvert.SerializeObject(_gameState);
            PlayerPrefs.SetString(GAME_STATE_KEY, gameStateJson);
        }
    }
}