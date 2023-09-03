using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal sealed class WorldCleanupUpdateLoopItem : WorldRepeatableLoopItem
    {
        internal WorldCleanupUpdateLoopItem(World world) : base(world)
        {
        }
    
        protected override void OnMoveNext()
        {
            World.CleanupUpdate(Time.deltaTime);
        }
    }
}