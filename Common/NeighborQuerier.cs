namespace RIT.AI.Flocking
{
    using DataStructures.ViliWonka.KDTree;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class NeighborQuerier
    {
        IBoid[] _boids;
        Vector3[] _boidsPosition => _boids.Select(b => b.Position).ToArray();
        KDTree _partitionedWorld;

        KDQuery queryP;
        List<int> queryResult = new List<int>();

        public NeighborQuerier(in IBoid[] boids)
        {
            _boids = boids;
            queryP = new KDQuery();
            _partitionedWorld = new KDTree(_boidsPosition, 1);
        }

        public void UpdateWorld()
        {
            _partitionedWorld.Build(_boids.Select(b => b.Position).ToArray(), 1);
        }

        public void GetNeighbors(in Vector3 query, in float searchRadius, ref List<Vector3> neighborsPosition)
        {
            queryResult.Clear();
            neighborsPosition.Clear();
            queryP.Radius(_partitionedWorld, query, searchRadius, queryResult);
            
            foreach (int index in queryResult)
            {
                neighborsPosition.Add(_boids[index].Position);
            }
        }
    }
}
