namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public abstract class ParallelCompositeNode : BehaviorNode
    {
        protected readonly IBehaviorNode[] _childNodes;

        public ParallelCompositeNode(IBehaviorNode[] childNodes)
        {
            _childNodes = childNodes;
        }

        public override void Reset()
        {
            base.Reset();

            foreach (var child in _childNodes)
                child.Reset();
        }

        protected abstract BehaviorNodeStatus CompletionStatus { get; }

        protected abstract bool ShouldContinueOnStatus(BehaviorNodeStatus status);

        protected override BehaviorNodeStatus OnExecute()
        {
            bool allNodesCompleted = true;

            foreach (var childNode in _childNodes)
            {
                var childNodeStatus = childNode.Execute();

                if (childNodeStatus != BehaviorNodeStatus.Running)
                {
                    if (!ShouldContinueOnStatus(childNodeStatus))
                    {
                        foreach (var childNodeToReset in _childNodes)
                            if (childNodeToReset != childNode)
                                childNodeToReset.Reset();

                        return childNodeStatus;
                    }
                }
                else
                {
                    allNodesCompleted = false;
                }
            }

            if (allNodesCompleted)
                return CompletionStatus;

            return BehaviorNodeStatus.Running;
        }
    }
}
