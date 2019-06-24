using System.Collections.Generic;
using UnityEngine;

namespace RIT.AI.Flocking
{
    public abstract class FlockingAgent : MonoBehaviour, IBoid
    {
        [SerializeField] protected Transform _transform;

        readonly HashSet<FlockingStrategy> _flockings = new HashSet<FlockingStrategy>();
        float _sumOfFlockingWeights = 1;

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
                _sumOfFlockingWeights += strategy.Weight;
            }
        }

        protected virtual void Update() => UpdateSteering();

        protected virtual void UpdateSteering()
        {
            if (Mass > 0)
            {
                Velocity += GetAveragedSteering() / Mass;
            }
            Velocity = Vector3.ClampMagnitude(Velocity, MaxSpeed);
            Position += Velocity * Time.deltaTime;
        }

        protected virtual Vector3 GetAveragedSteering()
        {
            Vector3 resultingSteering = Vector3.zero;
            if (_sumOfFlockingWeights > 0)
            {
                resultingSteering = SteeringsSum() / _sumOfFlockingWeights;
            }
            return resultingSteering;
        }

        protected virtual Vector3 SteeringsSum()
        {
            Vector3 sum = Vector3.zero;
            foreach (var flocking in _flockings)
            {
                sum += flocking.Steering;
            }
            return sum;
        }
    }
}

