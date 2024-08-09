namespace GameEngine.Installers
{
    public interface ISaveLoader
    {
        void LoadGame(SceneInstaller sceneInstaller);
        void SaveGame(SceneInstaller sceneInstaller);
    }
}