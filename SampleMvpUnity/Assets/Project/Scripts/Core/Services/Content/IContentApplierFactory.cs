using System;
using Project.Scripts.Core.Services.Coroutine;

namespace Core.Content
{
    public interface IContentApplierFactory
    {
        ICoroutine Create<T>(string address, Action<T> action) where T : class;
    }
}