using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Content
{
    public interface IContentService
    {
        IEnumerable<string> HandleContents { get; }
        
        Task LoadAsync<T>(string id);

        void Unload();
        void Unload(string id);
        void Unload(IEnumerable<string> ids);

        float PercentComplete();
        float PercentComplete(string id);
        float PercentComplete(IEnumerable<string> ids);

        bool IsLoaded(string id);
        bool IsLoading(string id);

        T Get<T>(string id) where T : class;
    }
}