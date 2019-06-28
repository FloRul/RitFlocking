using System.Collections.Generic;
using UnityEngine;

namespace RIT.AI.Flocking
{
    public abstract class FlockingAgent : MonoBehaviour, IBoid
    {
        [SerializeField] protected Transform _transform;

        readonly List<FlockingStrategy> _flockings = new List<FlockingStrategy>();

        public abstract float MaxSpeed      { get; }
        public abstract float SlowingRadius { get; }
        public abstract float Mass          { get; }

        public Vector3 Velocity { get; set; }
        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public void ClearFlockings() => _flockings.Clear();

        public void AddFlocking(FlockingStrategy strategy)
        {
            if (strategy != null)
            {
                _flockings.Add(strategy);
            }
        }

        protected virtual void Update() => UpdateSteering();

        protected virtual void UpdateSteering()
        {
            if (_flockings.Count > 0)
            {
                if (Mass > 0)
                {
                    Velocity += ResultingSteering() / Mass;
                }
                Velocity = Vector3.ClampMagnitude(Velocity, MaxSpeed);
                Position += Velocity * Time.deltaTime;
            }
        }
        
        protected virtual Vector3 ResultingSteering()
        {
            Vector3 sum = Vector3.zero;
            if (_flockings.Count > 0)
            {
                foreach (var flocking in _flockings)
                {
                    sum += flocking.Steering * flocking.Weight;
                }
                sum /= _flockings.Count;
            }
            return sum;
        }
    }
}

