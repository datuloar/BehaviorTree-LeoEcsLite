using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public abstract class BehaviorTreeConfig : ScriptableObject
    {
        public abstract IBehaviorNode CreateBehaviorTree(EcsWorld world, int ownerEntity, DiContainer diContainer);
    }
}