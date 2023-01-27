using System;
using System.Threading.Tasks;
using Core.Content;
using Project.Scripts.Core;
using Project.Scripts.Game.Screens.MainScreen.Areas.Ui.Views;
using UnityEngine;

namespace Project.Scripts.Game.Screens.MainScreen.Areas.Ui.Presenters
{
    public class MenuUiPresenter : IDisposable, IAsyncInitializable
    {
        private readonly IContentService _contentService;
        private MenuUiView _view;

        public MenuUiPresenter(IContentService contentService)
        {
            _contentService = contentService;
        }

        public Task InitializeAsync()
        {
            _view = UnityEngine.Object.Instantiate(_contentService.Get<GameObject>("Assets/Project/Prefabs/Screens/Main/MainScreen.prefab")).GetComponent<MenuUiView>();
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(_view);
        }
    }
}