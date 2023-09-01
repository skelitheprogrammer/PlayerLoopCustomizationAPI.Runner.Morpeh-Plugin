using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal class WorldUpdateLoopItem : WorldRepeatableLoopItem
    {
        public WorldUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.Update(Time.deltaTime);
        }
    }
}