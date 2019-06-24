
namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class PursuitStrategy : AbstractSeekStrategy
    {
        readonly IBoid _target;

        public PursuitStrategy(IBoid host, float weight, IBoid target) : base(host, weight)
        {
            _target = target;
        }

        protected override Vector3 TargetPosition => FuturePosition();

        virtual protected Vector3 FuturePosition()
        {
            var distance = (_target.Position - Host.Position).magnitude;
            var updateAhead = distance / Host.MaxSpeed;
            Vector3 futurePosition = _target.Position + _target.Velocity * updateAhead;
            return futurePosition;
        }
    } 
}
