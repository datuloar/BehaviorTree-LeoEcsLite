using UnityEngine;

namespace _Game.Scripts.Runtime.Core.AI.BehaviorTree
{
    public class WaitNode : BehaviorNode
    {
        private readonly float _duration;

        private float _startTime;

        public WaitNode(float duration)
        {
            _duration = duration;
        }

        protected override void OnStarted()
        {
            _startTime = Time.time;
        }

        protected override BehaviorNodeStatus OnExecute()
        {
            if (Time.time < _startTime + _duration)
                return BehaviorNodeStatus.Running;
            else
                return BehaviorNodeStatus.Success;
        }
    }
}