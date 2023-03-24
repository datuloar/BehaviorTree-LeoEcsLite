namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class RandomSelector : BehaviorNode
    {
        private readonly System.Random _random;
        private readonly IBehaviorNode[] _childNodes;

        public RandomSelector(IBehaviorNode[] childNodes)
        {
            _childNodes = childNodes;

            _random = new System.Random();
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            int rand = _random.Next(_childNodes.Length);

            return _childNodes[rand].Execute() == BehaviorNodeStatus.Success
                ? BehaviorNodeStatus.Success
                : BehaviorNodeStatus.Running;
        }
    }
}