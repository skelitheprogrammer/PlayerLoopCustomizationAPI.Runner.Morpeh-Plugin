using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal sealed class WorldFixedUpdateLoopItem : WorldRepeatableLoopItem
    {
        internal WorldFixedUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.FixedUpdate(Time.deltaTime);
        }
    }
}