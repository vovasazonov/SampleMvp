using System.Threading.Tasks;

namespace Project.Scripts.Core
{
    public interface IAsyncInitializable
    {
        Task InitializeAsync();
    }
}