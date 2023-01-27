using System.Threading.Tasks;

namespace Project.Scripts.Core.Services.Screen
{
    public interface IScreensService
    {
        string Current { get; }
        
        Task SwitchAsync(string screenId);
    }
}