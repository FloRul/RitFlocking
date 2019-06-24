
namespace RIT.AI.Flocking
{
    using System;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class WanderStrategy : FlockingStrategy
    {
		WanderParams _wanderParams;

        public override Vector3 Steering { get => WanderInsideCircle(_wanderParams); }

		public WanderStrategy(IBoid host, float weight, WanderParams wanderParams)
			:base(host, weight)
		{
			_wanderParams = wanderParams;
		}

        virtual protected Vector3 WanderInsideCircle(WanderParams wanderParams)
		{
			Vector3 desiredVelocity = GetWanderForce().normalized;
			desiredVelocity *= Host.MaxSpeed;

			return desiredVelocity;

			Vector3 GetWanderForce()
			{
				Vector3 wanderForce = new Vector3();
				if ((Host.Position + wanderParams.AreaPosition).magnitude > wanderParams.AreaRadius && wanderParams.AreaRadius > 0)
				{
					var directionToCenter = (wanderParams.AreaPosition - Host.Position).normalized;
                    wanderForce = Host.Velocity.normalized + directionToCenter;
                }
				else if (Random.value < wanderParams.TurnChance)
				{
					wanderForce = GetRandomWanderForce();
				}

				return wanderForce;
			}

			Vector3 GetRandomWanderForce()
			{
				var circleCenter = Host.Velocity.normalized * wanderParams.CircleDistance;
				var randomPoint = Random.insideUnitSphere;
				var displacement = new Vector3(randomPoint.x, randomPoint.y, randomPoint.z) * wanderParams.CircleRadius;
				var wanderForce = circleCenter + displacement;

				return wanderForce;
			}
		}
    }
}