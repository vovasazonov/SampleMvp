using Zenject;

namespace Project.Scripts.Game.Screens.LoadingScreen
{
    public class LoadingScreenInstaller : Installer<LoadingScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().AsSingle();
        }
    }
}