using System;
using UnityEngine;

namespace Core.Content
{
    public sealed class PoolableDisposableView<T> : IDisposableContent<T> where T : MonoBehaviour
    {
        private Action<T> _disposing;
        public T Value { get; private set; }

        public PoolableDisposableView(T value, Action<T> disposing)
        {
            _disposing = disposing;
            Value = value;
        }

        public void Dispose()
        {
            if (_disposing != null)
            {
                _disposing?.Invoke(Value);
                Value.gameObject.SetActive(false);
                Value = null;
                _disposing = null;
            }
        }
    }
}