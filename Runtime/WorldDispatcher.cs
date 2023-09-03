using System;
using PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems;
using Scellecs.Morpeh;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    internal static class WorldDispatcher
    {
        internal static IDisposable[] Dispatch(World world)
        {
            WorldFixedUpdateLoopItem worldFixedUpdateLoopItem = new(world);
            Registrar.Dispatch(0, worldFixedUpdateLoopItem);

            WorldUpdateLoopItem worldUpdateLoopItem = new(world);
            Registrar.Dispatch(1, worldUpdateLoopItem);

            WorldLateUpdateLoopItem worldLateUpdateLoopItem = new(world);
            Registrar.Dispatch(2, worldLateUpdateLoopItem);

            WorldCleanupUpdateLoopItem worldCleanupUpdateLoopItem = new(world);
            Registrar.Dispatch(3, worldCleanupUpdateLoopItem);

            return new IDisposable[]
            {
                worldFixedUpdateLoopItem,
                worldUpdateLoopItem,
                worldLateUpdateLoopItem,
                worldCleanupUpdateLoopItem
            };
        }
    }
}