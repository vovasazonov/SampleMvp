using System;
using System.Threading.Tasks;

namespace Project.Scripts.Core.Services.Screen
{
    public interface IScreenFactory
    {
        string Id { get; }
        
        Task<IDisposable> CreateAsync();
    }
}