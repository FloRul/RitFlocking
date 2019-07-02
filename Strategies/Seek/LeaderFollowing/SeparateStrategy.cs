namespace RIT.AI.Flocking
{
    using System.Collections.Generic;
    using UnityEngine;
    public class SeparateStrategy : FlockingStrategy
    {
        IBoid[] _neighbors;
        float _separationRadius;

        public SeparateStrategy(IBoid host, float weight, IBoid[] neighbors, float separationRadius) : base(host, weight)
        {
            _neighbors = neighbors;
            _separationRadius = separationRadius;
        }

        public override Vector3 Steering => Separate();

        Vector3 Separate()
        {
            Vector3 force = new Vector3();
            int nearestNeighbors = 0;

            foreach (var boid in _neighbors)
            {
                if ((boid.Position - Host.Position).sqrMagnitude 
                    < Mathf.Pow(_separationRadius, 2))
                {
                    ++nearestNeighbors;
                    force += Host.Position - boid.Position;
                }
            }

            if (nearestNeighbors >= 1)
            {
                force /= nearestNeighbors;
            }
            force.Normalize();
            // TODO magic number
            return force * 8;
        }
    }

}
