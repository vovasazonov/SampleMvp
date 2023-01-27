using UnityEngine;

namespace Core.Content
{
    public sealed class ContentViewGenerator<T> : IContentGenerator<T> where T : MonoBehaviour
    {
        private readonly IContentService _contentService;
        private readonly Transform _parent;
        private readonly string _id;

        public ContentViewGenerator(IContentService contentService, Transform parent, string id)
        {
            _contentService = contentService;
            _parent = parent;
            _id = id;
        }
        
        public ContentViewGenerator(IContentService contentService, string id)
        {
            _contentService = contentService;
            _id = id;
        }

        public IDisposableContent<T> Generate()
        {
            var gameObject = _contentService.Get<GameObject>(_id);
            var component = gameObject.GetComponent<T>();
            var view = _parent == null ? Object.Instantiate(component) : Object.Instantiate(component, _parent);
            return new DisposableView<T>(view);
        }
    }
}