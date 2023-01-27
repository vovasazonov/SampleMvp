using UnityEngine;

namespace Project.Scripts.Core.Services.Logger
{
    public class UnityLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}