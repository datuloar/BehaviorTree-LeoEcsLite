using UnityEngine;

namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class LogNode : BehaviorNode
    {
        private readonly string _message;

        public LogNode(string message)
        {
            _message = message;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            Debug.Log(_message);
            return BehaviorNodeStatus.Success;
        }
    }
}