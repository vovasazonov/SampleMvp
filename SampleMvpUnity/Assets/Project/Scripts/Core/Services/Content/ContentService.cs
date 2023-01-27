using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.Content
{
    public sealed class ContentService : IContentService
    {
        private readonly IDictionary<string, AsyncOperationHandle> _handles = new Dictionary<string, AsyncOperationHandle>();

        public IEnumerable<string> HandleContents => _handles.Keys;

        public float PercentComplete()
        {
            return PercentComplete(_handles.Keys);
        }

        public float PercentComplete(string id)
        {
            float percent;

            if (_handles.TryGetValue(id, out var handle))
            {
                if (!handle.IsDone && handle.PercentComplete < 1)
                {
                    percent = handle.PercentComplete;
                }
                else if (handle.IsDone)
                {
                    percent = 1;
                }
                else
                {
                    percent = 0;
                }
            }
            else
            {
                percent = 0;
            }

            return percent;
        }
        
        public float PercentComplete(IEnumerable<string> ids)
        {
            int count = 0;
            float sum = ids.Select(i =>
            {
                ++count;
                return PercentComplete(i);
            }).Sum();
            return count != 0 ? sum / count : 0;
        }

        public bool IsLoaded(string id)
        {
            return _handles.ContainsKey(id) && _handles[id].IsDone && _handles[id].Status == AsyncOperationStatus.Succeeded;
        }

        public bool IsLoading(string id)
        {
            return _handles.ContainsKey(id) && _handles[id].Status != AsyncOperationStatus.Failed && !_handles[id].IsDone;
        }

        public async Task LoadAsync<T>(string id)
        {
            AsyncOperationHandle handle;

            if (_handles.ContainsKey(id))
            {
                handle = _handles[id];
            }
            else
            {
                handle = Addressables.LoadAssetAsync<T>(id);
                _handles.Add(id, handle);
            }

            await handle.Task;
        }

        public void Unload()
        {
            foreach (var handle in _handles.Values)
            {
                Addressables.Release(handle);
            }

            _handles.Clear();
        }

        public void Unload(string id)
        {
            if (_handles.ContainsKey(id))
            {
                var handle = _handles[id];
                _handles.Remove(id);
                Addressables.Release(handle);
            }
        }

        public void Unload(IEnumerable<string> ids)
        {
            foreach (var id in ids)
            {
                Unload(id);
            }
        }

        public T Get<T>(string id) where T : class
        {
            T value = _handles[id].Result as T;

            if (value == null)
            {
                throw new InvalidCastException($"Can't cast content to {typeof(T)}");
            }

            return value;
        }
    }
}