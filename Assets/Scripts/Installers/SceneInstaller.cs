using Zenject;

namespace GameEngine.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var view = FindObjectOfType<ResourcesViewProvider>();
            WoodBind(view.WoodView);
            StoneBind(view.StoneView);

            Container
                .Bind<IGameRepository>()
                .To<GameRepository>()
                .AsSingle();


            Container
                .BindInterfacesTo<ISaveLoader>();
        }

        private void WoodBind(ResourcesView view)
        {
            Container
                .Bind<WoodStorage>()
                .AsSingle()
                .WithArguments(0)
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
                .WithArguments(0)
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<StoneObserver>()
                .AsSingle()
                .WithArguments(view)
                .NonLazy();
        }
    }
}