using Zenject;

namespace GameEngine.Installers
{
    public interface ISaveLoader
    {
        void LoadGame(DiContainer diContainer, IGameRepository gameRepository);
        void SaveGame(DiContainer diContainer, IGameRepository gameRepository);
    }
}