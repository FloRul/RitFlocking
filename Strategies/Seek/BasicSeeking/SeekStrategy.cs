namespace RIT.AI.Flocking
{
	using UnityEngine;
    public class SeekStrategy : AbstractSeekStrategy
    {
        public SeekStrategy(
            IBoid host, 
            float weight, 
            ref Vector3 target)
            :base(host, weight)
		{
			SeekTargetPosition = target;
		}
    }
}