using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts.Core.Services.Coroutine
{
    public class CoroutineService : ICoroutineService
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineService(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }

        public ICoroutine Create(Func<IEnumerator> enumeratorGetter)
        {
            return new Coroutine(_monoBehaviour, enumeratorGetter);
        }
    }
}