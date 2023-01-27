using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Content
{
    public sealed class BuiltInViewGenerator<T> : IContentGenerator<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;

        public BuiltInViewGenerator(T prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public BuiltInViewGenerator(T prefab)
        {
            _prefab = prefab;
        }

        public IDisposableContent<T> Generate()
        {
            T view = _parent == null ? Object.Instantiate(_prefab) : Object.Instantiate(_prefab, _parent);
            return new DisposableView<T>(view);
        }
    }
}