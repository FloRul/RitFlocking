﻿namespace RIT.AI.Flocking
{
    using UnityEngine;
    public abstract class AbstractSeekStrategy : FlockingStrategy
    {
        protected abstract Vector3 TargetPosition { get; }
        public AbstractSeekStrategy(IBoid host, float weight) : base(host, weight) { }

        public sealed override Vector3 Steering => SeekPosition(TargetPosition);

        protected virtual Vector3 SeekPosition(Vector3 target)
        {
            Vector3 desiredVelocity = target - Host.Position;

            float distanceToTarget = desiredVelocity.magnitude;
            desiredVelocity.Normalize();

            if (distanceToTarget <= Host.SlowingRadius)
            {
                desiredVelocity *= (Host.MaxSpeed * distanceToTarget / Host.SlowingRadius);
            }
            else
            {
                desiredVelocity *= Host.MaxSpeed;
            }
            return desiredVelocity - Host.Velocity;
        }
    }
}