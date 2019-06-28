namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class FleeTargetStrategy : AbstractFleeStrategy
    {
        public override Vector3 FleeTargetPosition => FleeTarget.Position;

        public ITarget FleeTarget { get; }

        public FleeTargetStrategy(
            IBoid host, 
            float weight, 
            float proximityTreshold, 
            ITarget fleeTarget) 
            :base(host, weight, proximityTreshold)
        {
            FleeTarget = fleeTarget;
        }
    }
}
