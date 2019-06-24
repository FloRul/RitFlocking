namespace RIT.AI.Flocking
{
    using UnityEngine;
    public abstract class AbstractFleeStrategy : FlockingStrategy
    {
        public abstract Vector3 FleeTargetPosition { get; }

        public float ProximityTreshold { get; }

        public AbstractFleeStrategy(
            IBoid host, 
            float weight, 
            float proximityTreshold) 
            :base(host, weight)
        {
            ProximityTreshold = proximityTreshold;
        }

        public sealed override Vector3 Steering => FleePosition(FleeTargetPosition);

        protected virtual Vector3 FleePosition(Vector3 target)
        {
            Vector3 desiredVelocity = Host.Position - FleeTargetPosition;
            float distanceToTarget = desiredVelocity.magnitude;

            if (distanceToTarget < ProximityTreshold)
            {
                desiredVelocity = desiredVelocity.normalized * Host.MaxSpeed;
            }
            else { desiredVelocity = Vector3.zero; }

            return desiredVelocity - Host.Velocity;
        }
    }
}