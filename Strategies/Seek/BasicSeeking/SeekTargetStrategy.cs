namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class SeekTargetStrategy : AbstractSeekStrategy
    {
        public override Vector3 SeekTargetPosition => SeekTarget.Position;

        public ITarget SeekTarget { get; }

        public SeekTargetStrategy(
            IBoid host, 
            float weight, 
            ITarget target) 
            :base (host, weight)
        { 
            SeekTarget = target;
        }
    }
}
 