namespace RIT.AI.Flocking
{
	using UnityEngine;
    public class SeekStrategy : AbstractSeekStrategy
    {
        public override Vector3 SeekTargetPosition { get ; }

        public SeekStrategy(
            IBoid host, 
            float weight, 
            Vector3 target)
            :base(host, weight)
		{
			SeekTargetPosition = target;
		}
    }
}