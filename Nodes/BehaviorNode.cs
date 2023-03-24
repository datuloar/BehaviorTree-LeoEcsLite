using System.Collections.Generic;

namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public abstract class BehaviorNode : IBehaviorNode
    {
        public BehaviorNodeStatus Status { get; private set; }
        public bool IsStarted => Status != BehaviorNodeStatus.Idle;
        public bool IsFinished => Status > BehaviorNodeStatus.Running;

        public BehaviorNodeStatus Execute()
        {
            if (!IsStarted)
                OnStarted();

            Status = OnExecute();
            return Status;
        }

        public virtual void Reset() => Status = BehaviorNodeStatus.Idle;

        protected virtual void OnStarted() { }

        protected abstract BehaviorNodeStatus OnExecute();
    }
}