using Scellecs.Morpeh;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin.LoopItems
{
    internal abstract class WorldRepeatableLoopItem : RepeatableLoopItem
    {
        protected readonly World World;
        protected WorldRepeatableLoopItem(World world)
        {
            World = world;
        }

        public override bool MoveNext()
        {
            if (Disposed)
            {
                return false;
            }
            
            if (World.IsNullOrDisposed())
            {
                Dispose();
                return false;
            }
            
            OnMoveNext();

            return !Disposed;
        }
    }
}