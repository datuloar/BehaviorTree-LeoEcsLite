namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class ParallelSequenceNode : ParallelCompositeNode
    {
        public ParallelSequenceNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Success;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => status == BehaviorNodeStatus.Success;
    }
}
