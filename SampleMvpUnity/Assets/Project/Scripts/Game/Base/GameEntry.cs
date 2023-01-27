using Project.Scripts.Core.Services.Screen;
using Project.Scripts.Game.Screens.MainScreen;
using Zenject;

namespace Project.Scripts.Game.Base
{
    public class GameEntry : IInitializable
    {
        private readonly IScreensService _screensService;

        public GameEntry(IScreensService screensService)
        {
            _screensService = screensService;
        }

        public void Initialize()
        {
            _screensService.SwitchAsync(MainScreen.Id);
        }
    }
}