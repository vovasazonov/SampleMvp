using System;
using System.Threading.Tasks;
using Core.Content;
using Project.Scripts.Core;
using Project.Scripts.Game.Screens.MainScreen.Areas.Ui.Presenters;
using Project.Scripts.Game.Screens.MainScreen.Areas.Ui.Views;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Screens.MainScreen
{
    public class MainScreen : IDisposable, IAsyncInitializable
    {
        private readonly IContentService _contentService;
        private readonly MenuUiPresenter _menuUiPresenter;
        public static string Id => "MainScreen";

        public MainScreen(IContentService contentService, MenuUiPresenter menuUiPresenter)
        {
            _contentService = contentService;
            _menuUiPresenter = menuUiPresenter;
        }
        
        public async Task InitializeAsync()
        {
            // Here for example load content remotely or/and
            // initialize presenters to instantiate views
            Debug.Log("Main screen initialized");

            await _contentService.LoadAsync<GameObject>("Assets/Project/Prefabs/Screens/Main/MainScreen.prefab");

            await _menuUiPresenter.InitializeAsync();
        }

        public void Dispose()
        {
            // Here for example unload content
            Debug.Log("Main screen disposed");
            
            _contentService.Unload("Assets/Project/Prefabs/Screens/Main/MainScreen.prefab");
            
            _menuUiPresenter.Dispose();
        }

        public class ZenjectFactory : PlaceholderFactory<MainScreen>
        {
        }

        public class Factory : ScreenFactory<ZenjectFactory, MainScreen>
        {
            public override string Id => MainScreen.Id;

            public Factory(ZenjectFactory zenjectFactory) : base(zenjectFactory)
            {
            }
        }
    }
}