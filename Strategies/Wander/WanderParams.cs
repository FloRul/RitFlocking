using System;
using UnityEngine;

namespace RIT.AI.Flocking
{
    public class WanderParams
    {
        public Vector3 AreaPosition   { get; set; }
        public float   AreaRadius     { get; set; }
        public float   TurnChance     { get; set; }
        public float   CircleRadius   { get; set; }
        public float   CircleDistance { get; set; }

        public WanderParams(
            Vector3 areaPosition,
            float   areaRadius,
            float   turnChance,
            float   circleRadius,
            float   circleDistance)
        {
            AreaPosition   = areaPosition;
            AreaRadius     = areaRadius;
            TurnChance     = turnChance;
            CircleRadius   = circleRadius;
            CircleDistance = circleDistance;
        }
    }
}
