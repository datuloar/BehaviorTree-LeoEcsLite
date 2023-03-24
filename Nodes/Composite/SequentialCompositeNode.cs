namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public abstract class SequentialCompositeNode : BehaviorNode
    {
        private readonly IBehaviorNode[] _childNodes;

        public SequentialCompositeNode(IBehaviorNode[] childNodes)
        {
            _childNodes = childNodes;
        }

        protected abstract BehaviorNodeStatus ContinueStatus { get; }

        public override void Reset()
        {
            base.Reset();

            foreach (IBehaviorNode child in _childNodes)
                child.Reset();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            var runningChildIndex = GetRunningChildIndex();

            for (int i = runningChildIndex; i < _childNodes.Length; i++)
            {
                var childNodeStatus = _childNodes[i].Execute();

                if (childNodeStatus != ContinueStatus)
                {
                    ResetChildNodes(i);
                    return childNodeStatus;
                }
            }

            return ContinueStatus;
        }

        private int GetRunningChildIndex()
        {
            for (int i = 0; i < _childNodes.Length; i++)
                if (_childNodes[i].Status == BehaviorNodeStatus.Running)
                    return i;

            return 0;
        }

        private void ResetChildNodes(int endIndex)
        {
            for (int i = endIndex + 1; i < _childNodes.Length; i++)
                _childNodes[i].Reset();
        }
    }
}
