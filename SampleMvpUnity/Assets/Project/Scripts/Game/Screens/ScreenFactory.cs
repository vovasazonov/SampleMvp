using System;
using System.Threading.Tasks;
using Project.Scripts.Core;
using Project.Scripts.Core.Services.Screen;
using Zenject;

namespace Project.Scripts.Game.Screens
{
    public abstract class ScreenFactory<TZenjectFactory, TScreen> : IScreenFactory where TZenjectFactory : PlaceholderFactory<TScreen> where TScreen : IDisposable, IAsyncInitializable
    {
        private readonly TZenjectFactory _zenjectFactory;
        public abstract string Id { get; }

        protected ScreenFactory(TZenjectFactory zenjectFactory)
        {
            _zenjectFactory = zenjectFactory;
        }

        public async Task<IDisposable> CreateAsync()
        {
            var screen = _zenjectFactory.Create();
            await screen.InitializeAsync();
            return screen;
        }
    }
}