using Project.Scripts.Game.Screens.LoadingScreen.Areas.Ui.Presenters;
using Zenject;

namespace Project.Scripts.Game.Screens.LoadingScreen
{
    public class LoadingScreenInstaller : Installer<LoadingScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LoadingScreen>().AsSingle();
            Container.Bind<LoadingUiPresenter>().AsSingle();
        }
    }
}