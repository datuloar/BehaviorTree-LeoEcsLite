namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class SuccessNode : BehaviorNode
    {
        protected override BehaviorNodeStatus OnExecute() => BehaviorNodeStatus.Success;
    }
}