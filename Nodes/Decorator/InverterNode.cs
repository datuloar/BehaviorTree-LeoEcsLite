namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(IBehaviorNode childNode) : base(childNode) { }

        protected override BehaviorNodeStatus OnExecute()
        {
            var childStatus = _childNode.Execute();

            return childStatus switch
            {
                BehaviorNodeStatus.Success => BehaviorNodeStatus.Failure,
                BehaviorNodeStatus.Failure => BehaviorNodeStatus.Success,
                _ => childStatus,
            };
        }
    }
}