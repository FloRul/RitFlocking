namespace RIT.AI.Flocking
{
    using UnityEngine;
    public abstract class AbstractSeekStrategy : FlockingStrategy
    {
        public sealed override Vector3 Steering => SeekPosition(SeekTargetPosition);

        public virtual Vector3 SeekTargetPosition { get; set; }

        public AbstractSeekStrategy(
            IBoid host, 
            float weight) 
            :base(host, weight) { }

        protected virtual Vector3 SeekPosition(Vector3 target)
        {
            Vector3 desiredVelocity = target - Host.Position;

            float distanceToTarget = desiredVelocity.magnitude;
            desiredVelocity.Normalize();

            if (distanceToTarget <= Host.SlowingRadius && Host.SlowingRadius > 0)
            {
                desiredVelocity *= (Host.MaxSpeed * distanceToTarget / Host.SlowingRadius);
            }
            else { desiredVelocity *= Host.MaxSpeed; }

            return desiredVelocity - Host.Velocity;
        }
    }
}
