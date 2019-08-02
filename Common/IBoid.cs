namespace RIT.AI.Flocking
{
	using UnityEngine;
	public interface IBoid
	{
		Vector3 Position { get; set; }
		Vector3 Velocity { get; set; }
		float MaxSpeed { get; }
		float SlowingRadius { get; }
		float Mass { get; }
	}
}