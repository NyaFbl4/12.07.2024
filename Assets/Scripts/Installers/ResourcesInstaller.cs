using Zenject;

namespace GameEngine.Installers
{
    public class ResourcesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ResourcesViewProvider>();
            WoodBind(view.WoodView);
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
    }
}