using Project.Scripts.Core.Services;
using Project.Scripts.Game.Screens;
using Zenject;

namespace Project.Scripts.Game.Base
{
    public class BaseInstaller : Installer<BaseInstaller>
    {
        public override void InstallBindings()
        {
            ServicesInstaller.Install(Container);
            ScreensInstaller.Install(Container);

            Container.BindInterfacesTo<GameEntry>().AsSingle().NonLazy();
        }
    }
}