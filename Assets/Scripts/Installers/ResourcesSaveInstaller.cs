using Zenject;

namespace GameEngine
{
    public class ResourcesSaveInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<WoodSaveLoader>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesTo<StoneSaveLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}