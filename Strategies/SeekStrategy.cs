namespace RIT.AI.Flocking
{
	using UnityEngine;
    public class SeekStrategy : AbstractSeekStrategy
    {
        readonly Vector3 _target;
        protected override Vector3 TargetPosition { get => _target; }

        public SeekStrategy(IBoid host, float weight, Vector3 target):base(host, weight)
		{
			_target = target;
		}
    }
}