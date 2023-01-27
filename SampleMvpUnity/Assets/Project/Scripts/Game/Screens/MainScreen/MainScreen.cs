using System;
using System.Threading.Tasks;
using Project.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.Screens.MainScreen
{
    public class MainScreen : IDisposable, IAsyncInitializable
    {
        public static string Id => "MainScreen";

        public async Task InitializeAsync()
        {
            // Here for example load content remotely or/and
            // initialize presenters to instantiate views
            Debug.Log("Main screen initialized");
        }

        public void Dispose()
        {
            // Here for example unload content
            Debug.Log("Main screen disposed");
        }

        public class ZenjectFactory : PlaceholderFactory<MainScreen>
        {
        }

        public class Factory : ScreenFactory<ZenjectFactory, MainScreen>
        {
            public override string Id => MainScreen.Id;

            public Factory(ZenjectFactory zenjectFactory) : base(zenjectFactory)
            {
            }
        }
    }
}