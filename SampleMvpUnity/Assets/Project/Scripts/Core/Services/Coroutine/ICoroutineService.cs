using System;
using System.Collections;

namespace Project.Scripts.Core.Services.Coroutine
{
    public interface ICoroutineService
    {
        ICoroutine Create(Func<IEnumerator> func);
    }
}