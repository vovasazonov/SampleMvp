using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Scripts.Core.Services.Screen
{
    public class ScreensService : IScreensService
    {
        private readonly string _switchLoadingScreenId;
        private readonly Dictionary<string, IScreenFactory> _screenFactories;
        private readonly Queue<string> _screenToOpenQueue = new();
        private bool _isChanging;

        private IDisposable _currentScreen;

        public string Current { get; private set; }

        public ScreensService(string switchLoadingScreenId, List<IScreenFactory> screenFactories)
        {
            _switchLoadingScreenId = switchLoadingScreenId;
            _screenFactories = screenFactories.ToDictionary(k => k.Id, v => v);
        }

        public async Task SwitchAsync(string screenId)
        {
            _screenToOpenQueue.Enqueue(_switchLoadingScreenId);
            _screenToOpenQueue.Enqueue(screenId);

            if (!_isChanging)
            {
                await ChangeCurrent();
            }
        }

        private async Task ChangeCurrent()
        {
            _isChanging = true;

            while (_screenToOpenQueue.Count != 0)
            {
                var newScreenId = _screenToOpenQueue.Dequeue();
                var oldScreen = _currentScreen;
                
                Current = newScreenId;
                _currentScreen = await _screenFactories[Current].CreateAsync();
                
                oldScreen?.Dispose();
            }

            _isChanging = false;
        }
    }
}