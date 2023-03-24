namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class ParallelFirstCompleteNode : ParallelCompositeNode
    {
        public ParallelFirstCompleteNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus CompletionStatus => BehaviorNodeStatus.Success;

        protected override bool ShouldContinueOnStatus(BehaviorNodeStatus status) => false;
    }
}
