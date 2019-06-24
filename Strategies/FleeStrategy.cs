namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class FleeStrategy : FlockingStrategy
    {
        readonly ITarget _fleeTarget;
        readonly float _proximityTreshold;

        public FleeStrategy(IBoid host, float weight, ITarget target, float proximityTreshold) : base(host, weight)
        {
            _fleeTarget = target;
            _proximityTreshold = proximityTreshold;
        }

        public override Vector3 Steering { get => Flee(); }

        virtual protected Vector3 Flee()
        {
            Vector3 desiredVelocity = Host.Position - _fleeTarget.Position;
            float sqrDistanceToTarget = desiredVelocity.sqrMagnitude;

            if (sqrDistanceToTarget < Mathf.Pow(_proximityTreshold, 2))
            {
                desiredVelocity = desiredVelocity.normalized * Host.MaxSpeed;
            }
            else { desiredVelocity = Vector3.zero; }

            return desiredVelocity - Host.Velocity;
        }
    }
}
