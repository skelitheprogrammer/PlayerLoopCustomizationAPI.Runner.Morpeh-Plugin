using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    internal sealed class DispatcherWorldPlugin : IWorldPlugin
    {
        private static Dictionary<World, IDisposable[]> _disposables;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void RuntimeInitialize()
        {
            _disposables = new();
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

                _disposables.Remove(world);
            }
        }
    }
}