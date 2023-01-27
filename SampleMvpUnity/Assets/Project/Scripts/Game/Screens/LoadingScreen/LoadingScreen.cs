using System;
using System.Threading.Tasks;
using Core.Content;
using Project.Scripts.Core;
using Project.Scripts.Game.Screens.LoadingScreen.Areas.Ui.Presenters;
using Project.Scripts.Game.Screens.LoadingScreen.Areas.Ui.Views;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.Screens.LoadingScreen
{
    public class LoadingScreen : IDisposable, IAsyncInitializable
    {
        private readonly IContentService _contentService;
        private readonly LoadingUiPresenter _loadingUiPresenter;
        public static string Id => "LoadingScreen";

        public LoadingScreen(IContentService contentService, LoadingUiPresenter loadingUiPresenter)
        {
            _contentService = contentService;
            _loadingUiPresenter = loadingUiPresenter;
        }

        public async Task InitializeAsync()
        {
            // Here for example initialize percent bar to 0% and/or
            // initialize presenters
            Debug.Log("Loading screen initialized");

            await _contentService.LoadAsync<GameObject>("Assets/Project/Prefabs/Screens/Loading/LoadingScreen.prefab");

            await _loadingUiPresenter.InitializeAsync();

            await Task.Delay(3000);
        }

        public void Dispose()
        {
            // Here for example dispose presenters
            Debug.Log("Loading screen disposed");
            
            _contentService.Unload("Assets/Project/Prefabs/Screens/Loading/LoadingScreen.prefab");
            
            _loadingUiPresenter.Dispose();
        }

        public class ZenjectFactory : PlaceholderFactory<LoadingScreen>
        {
        }

        public class Factory : ScreenFactory<ZenjectFactory, LoadingScreen>
        {
            public override string Id => LoadingScreen.Id;

            public Factory(ZenjectFactory zenjectFactory) : base(zenjectFactory)
            {
            }
        }
    }
}