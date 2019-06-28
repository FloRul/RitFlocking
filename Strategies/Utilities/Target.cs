namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class Target : ITarget
    {
        public Vector3 Position { get; set; }

        public Target(Vector3 position)
        {
            Position = position;
        }

        public Target()
        {
            Position = default;
        }
    }
}
