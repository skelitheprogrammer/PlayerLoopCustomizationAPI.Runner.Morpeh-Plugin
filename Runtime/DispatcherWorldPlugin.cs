using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    internal sealed class DispatcherWorldPlugin : IWorldPlugin
    {
        private static readonly Dictionary<World, IDisposable[]> _disposables = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void RuntimeInitialize()
        {
            WorldExtensions.AddWorldPlugin(new DispatcherWorldPlugin());
        }

        void IWorldPlugin.Initialize(World world)
        {
            if (_disposables.ContainsKey(world))
            {
                throw new NullReferenceException();
            }
            
            IDisposable[] disposables = WorldDispatcher.Dispatch(world);
            _disposables.Add(world, disposables);
        }

        void IWorldPlugin.Deinitialize(World world)
        {
            if (_disposables.TryGetValue(world, out IDisposable[] disposables))
            {
                foreach (IDisposable disposable in disposables)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}