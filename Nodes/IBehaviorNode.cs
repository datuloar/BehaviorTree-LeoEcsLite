namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public interface IBehaviorNode
    {
        bool IsStarted { get; }     
        bool IsFinished { get; }    
        BehaviorNodeStatus Status { get; }
        
        BehaviorNodeStatus Execute();
        void Reset();
    }
}
