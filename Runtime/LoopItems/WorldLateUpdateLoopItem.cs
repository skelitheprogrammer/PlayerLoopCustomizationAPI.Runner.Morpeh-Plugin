using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal sealed class WorldLateUpdateLoopItem : WorldRepeatableLoopItem
    {
        internal WorldLateUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.LateUpdate(Time.deltaTime);
        }
    }
}