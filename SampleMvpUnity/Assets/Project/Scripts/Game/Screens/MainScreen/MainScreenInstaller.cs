using Zenject;

namespace Project.Scripts.Game.Screens.MainScreen
{
    public class MainScreenInstaller : Installer<MainScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainScreen>().AsSingle();
        }
    }
}