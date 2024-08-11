namespace GameEngine.Installers
{
    public interface ISaveLoader
    {
        void LoadGame( IGameRepository gameRepository);
        void SaveGame( IGameRepository gameRepository);
    }
}