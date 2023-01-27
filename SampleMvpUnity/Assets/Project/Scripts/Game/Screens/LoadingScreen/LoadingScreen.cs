using System;
using System.Threading.Tasks;
using Project.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Game.Screens.LoadingScreen
{
    public class LoadingScreen : IDisposable, IAsyncInitializable
    {
        public static string Id => "LoadingScreen";

        public async Task InitializeAsync()
        {
            // Here for example initialize percent bar to 0% and/or
            // initialize presenters
            Debug.Log("Loading screen initialized");
        }

        public void Dispose()
        {
            // Here for example dispose presenters
            Debug.Log("Loading screen disposed");
        }

        public class ZenjectFactory : PlaceholderFactory<LoadingScreen>
        {
        }

        public class Factory : ScreenFactory<ZenjectFactory, LoadingScreen>
        {
            public override string Id => LoadingScreen.Id;

            public Factory(ZenjectFactory zenjectFactory) : base(zenjectFactory)
            {
            }
        }
    }
}