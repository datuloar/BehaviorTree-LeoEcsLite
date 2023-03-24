namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class FailureNode : BehaviorNode
    {
        protected override BehaviorNodeStatus OnExecute() => BehaviorNodeStatus.Failure;
    }
}