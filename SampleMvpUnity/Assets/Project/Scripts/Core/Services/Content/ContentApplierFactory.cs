using System;
using System.Collections;
using Project.Scripts.Core.Services.Coroutine;

namespace Core.Content
{
    public class ContentApplierFactory : IContentApplierFactory
    {
        private readonly IContentService _contentService;
        private readonly ICoroutineService _coroutineFactory;

        public ContentApplierFactory(IContentService contentService, ICoroutineService coroutineFactory)
        {
            _contentService = contentService;
            _coroutineFactory = coroutineFactory;
        }

        public ICoroutine Create<T>(string address, Action<T> action) where T : class
        {
            return _coroutineFactory.Create(() => ApplyContent(address, action));
        }

        private IEnumerator ApplyContent<T>(string address, Action<T> action) where T : class
        {
            if (!_contentService.IsLoaded(address) && !_contentService.IsLoading(address))
            {
                _contentService.LoadAsync<T>(address);
            }

            while (_contentService.IsLoading(address))
            {
                yield return null;
            }

            if (_contentService.IsLoaded(address))
            {
                var content = _contentService.Get<T>(address);
                action?.Invoke(content);
            }
        }
    }
}