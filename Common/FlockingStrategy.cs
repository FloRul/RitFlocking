namespace RIT.AI.Flocking
{
    using UnityEngine;
    public abstract class FlockingStrategy
    {
        public IBoid Host { get; }
        public float Weight { get; }
        public abstract Vector3 Steering { get; }

        public FlockingStrategy(IBoid host, float weight)
        {
            Host = host;
            Weight = weight;
        }

    }
}
