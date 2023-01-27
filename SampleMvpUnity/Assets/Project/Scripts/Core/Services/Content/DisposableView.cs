using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Content
{
    public sealed class DisposableView<T> : IDisposableContent<T> where T : MonoBehaviour
    {
        public T Value { get; private set; }

        public DisposableView(T value)
        {
            Value = value;
        }

        public void Dispose()
        {
            if (Value != null)
            {
                if (Value is IDisposable disposable)
                {
                    disposable.Dispose();
                }
                else
                {
                    Object.Destroy(Value.gameObject);
                }
                Value = null;
            }
        }
    }
}