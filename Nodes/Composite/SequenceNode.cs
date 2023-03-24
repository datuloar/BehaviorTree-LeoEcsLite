namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class SequenceNode : SequentialCompositeNode
    {
        public SequenceNode(IBehaviorNode[] childNodes) : base(childNodes) { }

        protected override BehaviorNodeStatus ContinueStatus => BehaviorNodeStatus.Success;
    }
}
