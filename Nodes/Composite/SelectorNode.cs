namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class SelectorNode : SequentialCompositeNode
    {
        public SelectorNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Failure;
    }
}
