using Zenject;

namespace GameEngine.Installers
{
    public class ResourcesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ResourcesViewProvider>();
            WoodBind(view.WoodView);
            StoneBind(view.StoneView);
        }

        private void WoodBind(ResourcesView view)
        {
            Container
                .Bind<WoodStorage>()
                .AsSingle()
                .WithArguments(50L)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WoodObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
        
        private void StoneBind(ResourcesView view)
        {
            Container
                .Bind<StoneStorage>()
                .AsSingle()
                .WithArguments(0L)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<StoneObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
    }
}