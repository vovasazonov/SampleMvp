using Project.Scripts.Game.Screens.LoadingScreen;
using Project.Scripts.Game.Screens.MainScreen;
using Zenject;

namespace Project.Scripts.Game.Screens
{
    public class ScreensInstaller : Installer<ScreensInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<LoadingScreen.LoadingScreen, LoadingScreen.LoadingScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<LoadingScreenInstaller>();
            Container.BindInterfacesTo<LoadingScreen.LoadingScreen.Factory>().AsSingle();
            
            Container.BindFactory<MainScreen.MainScreen, MainScreen.MainScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<MainScreenInstaller>();
            Container.BindInterfacesTo<MainScreen.MainScreen.Factory>().AsSingle();
        }
    }
}