using PlayerLoopCustomizationAPI.Utils;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace PlayerLoopCustomizationAPI.Addons.Runner.MorpehPlugin
{
    internal static class Registrar
    {
        private struct MorpehWorldFixedUpdate
        {
        }

        private struct MorpehWorldUpdate
        {
        }

        private struct MorpehWorldLateUpdate
        {
        }

        private struct MorpehWorldCleanupUpdate
        {
        }

        private static readonly LoopRunner[] _loopRunners = new LoopRunner[4];

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Init()
        {
            for (int i = 0; i < _loopRunners.Length; i++)
            {
                _loopRunners[i] = new LoopRunner();
            }

            PlayerLoopSystem morpehFixedUpdateLoopSystem = PlayerLoopUtils.CreateSystem<MorpehWorldFixedUpdate>(_loopRunners[0].Run);
            PlayerLoopSystem morpehUpdateLoopSystem = PlayerLoopUtils.CreateSystem<MorpehWorldUpdate>(_loopRunners[1].Run);
            PlayerLoopSystem morpehLateUpdateLoopSystem = PlayerLoopUtils.CreateSystem<MorpehWorldLateUpdate>(_loopRunners[2].Run);
            PlayerLoopSystem morpehCleanupUpdateLoopSystem = PlayerLoopUtils.CreateSystem<MorpehWorldCleanupUpdate>(_loopRunners[3].Run);

            PlayerLoopAPI.AddAtEnd(ref morpehFixedUpdateLoopSystem, typeof(FixedUpdate));
            PlayerLoopAPI.AddAtEnd(ref morpehUpdateLoopSystem, typeof(Update));
            PlayerLoopAPI.AddAtEnd(ref morpehLateUpdateLoopSystem, typeof(PreLateUpdate));
            PlayerLoopAPI.AddAfter(ref morpehCleanupUpdateLoopSystem, typeof(MorpehWorldLateUpdate));
        }

        public static void Dispatch(int index, ILoopItem loopItem)
        {
            _loopRunners[index].Dispatch(loopItem);
        }
    }
}