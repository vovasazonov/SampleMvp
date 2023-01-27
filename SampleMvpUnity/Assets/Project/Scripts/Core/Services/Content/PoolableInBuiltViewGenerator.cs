using System.Collections.Generic;
using UnityEngine;

namespace Core.Content
{
    public sealed class PoolableInBuiltViewGenerator<T> : IContentGenerator<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly Queue<T> _views = new();

        public PoolableInBuiltViewGenerator(T prefab, Transform parent)
        {
            _prefab = prefab;
            _parent = parent;
        }

        public PoolableInBuiltViewGenerator(T prefab)
        {
            _prefab = prefab;
        }

        public IDisposableContent<T> Generate()
        {
            if (!_views.TryDequeue(out var value))
            {
                value = _parent == null ? Object.Instantiate(_prefab) : Object.Instantiate(_prefab, _parent);
            }

            value.gameObject.SetActive(true);
            return new PoolableDisposableView<T>(value, view => _views.Enqueue(view));
        }
    }
}