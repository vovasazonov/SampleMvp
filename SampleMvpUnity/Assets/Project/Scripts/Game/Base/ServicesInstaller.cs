using Project.Scripts.Core.Services.Coroutine;
using Project.Scripts.Core.Services.Logger;
using Project.Scripts.Core.Services.Screen;
using Project.Scripts.Game.Screens.LoadingScreen;
using Zenject;

namespace Project.Scripts.Game.Base
{
    public class ServicesInstaller : Installer<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CoroutineService>().AsSingle();
            Container.BindInterfacesTo<UnityLoggerService>().AsSingle();
            Container.BindInterfacesTo<ScreensService>().AsSingle();
            Container.Bind<string>().FromInstance(LoadingScreen.Id).WhenInjectedInto<ScreensService>();
        }
    }
}