using System;

namespace Core.Content
{
    public interface IDisposableContent<out T> : IDisposable
    {
        T Value { get; }
    }
}