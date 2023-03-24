namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public abstract class DecoratorNode : BehaviorNode
    {
        protected readonly IBehaviorNode _childNode;

        public DecoratorNode(IBehaviorNode childNode)
        {
            _childNode = childNode;
        }

        public override void Reset()
        {
            base.Reset();

            _childNode.Reset();
        }
    }
}