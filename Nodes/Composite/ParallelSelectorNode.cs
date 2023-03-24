namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class ParallelSelectorNode : ParallelCompositeNode
    {
        public ParallelSelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Failure;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => status == BehaviorNodeStatus.Failure;
    }
}
