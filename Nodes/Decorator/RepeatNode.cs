namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class RepeatNode : DecoratorNode
    {
        private readonly BehaviorNodeStatus? _stopStatus;

        public RepeatNode(IBehaviorNode childNode, BehaviorNodeStatus? stopStatus = null) : base(childNode)
        {
            _stopStatus = stopStatus;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            if (_childNode.Status > BehaviorNodeStatus.Running)
                _childNode.Reset();

            var childStatus = _childNode.Execute();

            if (_stopStatus.HasValue && childStatus == _stopStatus.Value)
                return _stopStatus.Value;

            return BehaviorNodeStatus.Running;
        }
    }
}