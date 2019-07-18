namespace RIT.AI.Flocking
{
	using UnityEngine;
    using RIT.Optimization.KDTree;
	public interface IBoid : INode
	{
		new Vector3 Position { get; set; }
		Vector3 Velocity { get; set; }
		float MaxSpeed { get; }
		float SlowingRadius { get; }
		float Mass { get; }
	}
}