using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal sealed class WorldUpdateLoopItem : WorldRepeatableLoopItem
    {
        internal WorldUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.Update(Time.deltaTime);
        }
    }
}