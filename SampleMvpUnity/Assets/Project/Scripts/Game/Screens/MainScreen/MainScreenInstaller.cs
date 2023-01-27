using Project.Scripts.Game.Screens.MainScreen.Areas.Ui.Presenters;
using Zenject;

namespace Project.Scripts.Game.Screens.MainScreen
{
    public class MainScreenInstaller : Installer<MainScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainScreen>().AsSingle();
            Container.Bind<MenuUiPresenter>().AsSingle();
        }
    }
}