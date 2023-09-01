using Scellecs.Morpeh;
using UnityEngine;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal class WorldFixedUpdateLoopItem : WorldRepeatableLoopItem
    {
        public WorldFixedUpdateLoopItem(World world) : base(world)
        {
        }

        protected override void OnMoveNext()
        {
            World.FixedUpdate(Time.deltaTime);
        }
    }
}