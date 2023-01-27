using System;
using System.Threading.Tasks;
using Core.Content;
using Project.Scripts.Core;
using Project.Scripts.Game.Screens.LoadingScreen.Areas.Ui.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Scripts.Game.Screens.LoadingScreen.Areas.Ui.Presenters
{
    public class LoadingUiPresenter : IDisposable, IAsyncInitializable
    {
        private readonly IContentService _contentService;
        private LoadingUiView _view;

        public LoadingUiPresenter(IContentService contentService)
        {
            _contentService = contentService;
        }

        public Task InitializeAsync()
        {
            _view = Object.Instantiate(_contentService.Get<GameObject>("Assets/Project/Prefabs/Screens/Loading/LoadingScreen.prefab")).GetComponent<LoadingUiView>();
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Object.Destroy(_view);
        }
    }
}