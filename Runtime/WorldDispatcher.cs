using System;
using PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems;
using Scellecs.Morpeh;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    internal class WorldDispatcher : IDisposable
    {
        private World _world;
        private IDisposable[] _disposables;

        private bool _disposed;
        
        public WorldDispatcher(World world)
        {
            _world = world;
        }

        public void Dispatch()
        {
            if (_disposed)
            {
                return;
            }
            
            WorldFixedUpdateLoopItem worldFixedUpdateLoopItem = new(_world);
            Registrar.Dispatch(0, worldFixedUpdateLoopItem);

            WorldUpdateLoopItem worldUpdateLoopItem = new(_world);
            Registrar.Dispatch(1, worldUpdateLoopItem);

            WorldLateUpdateLoopItem worldLateUpdateLoopItem = new(_world);
            Registrar.Dispatch(2, worldLateUpdateLoopItem);
            
            WorldCleanupUpdateLoopItem worldCleanupUpdateLoopItem = new(_world);
            Registrar.Dispatch(3, worldCleanupUpdateLoopItem);

            _disposables = new IDisposable[]
            {
                worldFixedUpdateLoopItem,
                worldUpdateLoopItem,
                worldLateUpdateLoopItem,
                worldCleanupUpdateLoopItem
            };
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            
            foreach (IDisposable disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables = null;
            
            _world = null;
            
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
