using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal class WorldCleanupUpdateLoopItem : WorldRepeatableLoopItem
    {
        public WorldCleanupUpdateLoopItem(World world) : base(world)
        {
        }
    
        protected override void OnMoveNext()
        {
            World.CleanupUpdate(Time.deltaTime);
        }
    }
}