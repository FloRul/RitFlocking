namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class PursuitStrategy : AbstractSeekStrategy
    {
        public override Vector3 SeekTargetPosition => FuturePosition();

        public IBoid PursuitTarget { get; }

        public PursuitStrategy(
            IBoid host, 
            float weight, 
            IBoid target) 
            :base(host, weight)
        {
            PursuitTarget = target;
        }

        virtual protected Vector3 FuturePosition()
        {
            var distance = (PursuitTarget.Position - Host.Position).magnitude;
            var updateAhead = distance / Host.MaxSpeed;
            Vector3 futurePosition = PursuitTarget.Position + PursuitTarget.Velocity * updateAhead;
            return futurePosition;
        }
    } 
}
