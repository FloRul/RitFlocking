namespace RIT.AI.Flocking
{
    using System.Collections.Generic;
    using UnityEngine;
    public class SeparateStrategy : FlockingStrategy
    {
        float _sqrSeparationRadius;
        float _separationIntensity;
        NeighborQuerier _neighborQuerier;
        List<Vector3> _neighborsPosition = new List<Vector3>();

        public SeparateStrategy(
            IBoid host,
            float weight,
            float sqrSeparationRadius,
            float separationIntensity,
            NeighborQuerier neighborQuerier) 
            : base(host, weight)
        {
            _sqrSeparationRadius = sqrSeparationRadius;
            _separationIntensity = separationIntensity;
            _neighborQuerier = neighborQuerier;
        }

        public override Vector3 Steering => SeparateFromNeighbors();

        Vector3 SeparateFromNeighbors()
        {
            Vector3 force = Vector3.zero;
            _neighborQuerier.GetNeighbors(Host.Position, _sqrSeparationRadius, ref _neighborsPosition);
            if (_neighborsPosition.Count > 0)
            {
                foreach (Vector3 v in _neighborsPosition)
                {
                    force += Host.Position - v;
                }
                (force /= _neighborsPosition.Count).Normalize();
            }
            return force * _separationIntensity;
        }
    }
}
