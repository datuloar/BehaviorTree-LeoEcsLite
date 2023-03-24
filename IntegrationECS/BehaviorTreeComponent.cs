using System;
using _Game.Scripts.Runtime.Core.AI.BehaviorTree;

namespace Core.Ecs.Components
{
    [Serializable]
    public struct BehaviorTreeComponent
    {
        public BehaviorTreeConfig Config;
        [NonSerialized] public IBehaviorNode RootNode;
        [NonSerialized] public bool IsInitialized;
    }
}