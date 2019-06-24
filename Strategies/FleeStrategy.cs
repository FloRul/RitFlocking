namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class FleeStrategy : AbstractFleeStrategy
    {
        public override Vector3 FleeTargetPosition { get; }

        public FleeStrategy(
            IBoid host, 
            float weight, 
            float proximityTreshold, 
            Vector3 fleeTarget) 
            :base(host, weight, proximityTreshold)
        {
            FleeTargetPosition = fleeTarget;
        }

    }
}
