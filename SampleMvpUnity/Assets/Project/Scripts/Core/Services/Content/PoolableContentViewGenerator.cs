using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Scripts.Core;
using UnityEngine;

namespace Core.Content
{
    public sealed class PoolableContentViewGenerator<T> : IContentGenerator<T>, IAsyncInitializable where T : MonoBehaviour
    {
        private readonly IContentService _contentService;
        private readonly Transform _parent;
        private readonly string _id;
        private readonly Queue<T> _views = new();

        public PoolableContentViewGenerator(IContentService contentService, Transform parent, string id)
        {
            _contentService = contentService;
            _parent = parent;
            _id = id;
        }

        public PoolableContentViewGenerator(IContentService contentService, string id)
        {
            _contentService = contentService;
            _id = id;
        }

        public IDisposableContent<T> Generate()
        {
            if (!_views.TryDequeue(out var value))
            {
                GameObject gameObject = _contentService.Get<GameObject>(_id);
                var component = gameObject.GetComponent<T>();
                value = _parent == null ? Object.Instantiate(component) : Object.Instantiate(component, _parent);
            }

            value.gameObject.SetActive(true);
            return new PoolableDisposableView<T>(value, view => _views.Enqueue(view));
        }

        public async Task InitializeAsync()
        {
            await _contentService.LoadAsync<GameObject>(_id);
        }
    }
}