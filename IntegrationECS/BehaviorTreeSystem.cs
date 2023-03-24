using Core.Ecs.Components;
using Core.Ecs.Tags;
using Leopotam.EcsLite;
using Zenject;

public class BehaviorTreeSystem : IEcsRunSystem
{
    private readonly DiContainer _diContainer;
    private readonly EcsWorld _world;
    private readonly EcsFilter _filter;
    private readonly EcsPool<BehaviorTreeComponent> _behaviorTreePool;

    public BehaviorTreeSystem(EcsWorld world, DiContainer diContainer)
    {
        _world = world;
        _diContainer = diContainer;

        _filter = _world
            .Filter<BehaviorTreeComponent>()
            .Exc<DeadTag>()
            .End();

        _behaviorTreePool = _world.GetPool<BehaviorTreeComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var behaviorTree = ref _behaviorTreePool.Get(entity);

            if (!behaviorTree.IsInitialized)
            {
                behaviorTree.RootNode = behaviorTree.Config.CreateBehaviorTree(_world, entity, _diContainer);
                behaviorTree.IsInitialized = true;
            }

            behaviorTree.RootNode.Execute();
        }
    }
}
