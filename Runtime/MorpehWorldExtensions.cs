using System.Runtime.CompilerServices;
using Scellecs.Morpeh;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    public static class MorpehWorldExtensions
    {
        private static readonly ConditionalWeakTable<World, WorldDispatcher> _worldMap = new();
    
        public static void IntegrateLoop(this World world)
        {
            world.UpdateByUnity = false;
        
            if (!_worldMap.TryGetValue(world, out WorldDispatcher dispatcher))
            {
                dispatcher = new WorldDispatcher(world);
                _worldMap.Add(world, dispatcher);
            }
            
            dispatcher.Dispatch();
            
        }
    }
}