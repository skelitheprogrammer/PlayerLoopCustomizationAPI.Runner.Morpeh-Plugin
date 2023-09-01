using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal class WorldLateUpdateLoopItem : WorldRepeatableLoopItem
    {
        public WorldLateUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.LateUpdate(Time.deltaTime);
        }
    }
}