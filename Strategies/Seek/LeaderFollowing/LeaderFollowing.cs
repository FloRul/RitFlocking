namespace RIT.AI.Flocking
{
    using UnityEngine;
    using System.Collections.Generic;
    public class LeaderFollowing : FlockingStrategy
    {
        public override Vector3 Steering => ComputedStrategy();


        IBoid[] _neighbors;
        LeaderTail _leaderTail;
        float _separationRadius { get; }

        protected FlockingStrategy _arriveToleader;
        protected FlockingStrategy _evadeLeaderPath;
        protected FlockingStrategy _neighborsSeparation;

        public LeaderFollowing(
            IBoid host,
            float weight,
            IBoid leader,
            float maxDistancefromLead,
            IBoid[] neighbors,
            float separationRadius = .1f) 
            :base(host, weight)
        {
            _neighbors = neighbors;

            _leaderTail = new LeaderTail(leader, maxDistancefromLead); 

            _arriveToleader = new SeekTargetStrategy(host, weight, _leaderTail);
            _neighborsSeparation = new SeparateStrategy(host, 1, neighbors, separationRadius);
            _evadeLeaderPath = new NullStrategy(host);
        }

        protected virtual Vector3 ComputedStrategy()
        {
            return ( _arriveToleader.Steering + 
                     _evadeLeaderPath.Steering + 
                     _neighborsSeparation.Steering ) / 3;
        }
        
        private class LeaderTail : ITarget
        {
            IBoid _leader;
            float _maxDistanceFromLead;

            public LeaderTail(IBoid leader, float maxDistancefromLead)
            {
                _leader = leader;
                _maxDistanceFromLead = maxDistancefromLead;
            }

            public Vector3 Position =>
                _leader.Position 
                - _leader.Velocity.normalized 
                * _maxDistanceFromLead;
        }
    }
}
