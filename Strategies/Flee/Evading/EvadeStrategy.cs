namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class EvadeStrategy : AbstractFleeStrategy
    {
        public override Vector3 FleeTargetPosition => FuturePosition();

        public IBoid EvadeTarget { get; }

        public EvadeStrategy(
            IBoid host, 
            float weight, 
            float proximityTreshold, 
            IBoid target) 
            :base(host, weight, proximityTreshold)
        {
            EvadeTarget = target;
        }

        virtual protected Vector3 FuturePosition()
        {
            var distance = (EvadeTarget.Position - Host.Position).magnitude;
            var updateAhead = distance / Host.MaxSpeed;
            Vector3 futurePosition = EvadeTarget.Position + EvadeTarget.Velocity * updateAhead;
            return futurePosition;
        }
    }
}
