namespace RIT.AI.Flocking
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class SeparateStrategy : FlockingStrategy
    {
        IBoid[] _neighbors;
        float _sqrSeparationRadius;
        float _separationIntensity;

        public SeparateStrategy(
            IBoid host,
            float weight,
            IBoid[] neighbors,
            float sqrSeparationRadius,
            float separationIntensity) 
            : base(host, weight)
        {
            _neighbors = neighbors;
            _sqrSeparationRadius = sqrSeparationRadius;
            _separationIntensity = separationIntensity;
        }

        public override Vector3 Steering => Separate();

        Vector3 Separate()
        {
            Vector3 force = Vector3.zero;
            foreach (var neighborPosition in _neighbors.Select(n=>n.Position))
            {
                if ((neighborPosition - Host.Position).sqrMagnitude
                    < Mathf.Pow(_sqrSeparationRadius, 2))
                {
                    force += Host.Position - neighborPosition;
                }
            }
            (force /= _neighbors.Count() > 0 ? _neighbors.Count() : 1).Normalize();

            return force * _separationIntensity;
        }
    }

}
