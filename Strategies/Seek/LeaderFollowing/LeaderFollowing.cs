namespace RIT.AI.Flocking
{
    using UnityEngine;
    public class LeaderFollowing : FlockingStrategy
    {
        public override Vector3 Steering => (_arriveToleader.Steering + _neighborsSeparation.Steering) / 2;
        
        readonly LeaderTail _leaderTail;
        readonly float _separationRadius;

        protected FlockingStrategy _arriveToleader;
        protected FlockingStrategy _neighborsSeparation;

        public LeaderFollowing(
            IBoid host,
            float followTailweight,
            IBoid leader,
            float maxDistancefromLead,
            float separateWeight,
            NeighborQuerier neighborQuerier,
            float separationRadius) 
            :base(host, 1 )
        {
            _leaderTail = new LeaderTail(leader, maxDistancefromLead); 
            _arriveToleader = new SeekTargetStrategy(host, followTailweight, _leaderTail);
            _neighborsSeparation = new SeparateStrategy(host, separateWeight, separationRadius, 5, neighborQuerier);
        }

        class LeaderTail : ITarget
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
