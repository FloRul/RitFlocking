using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RIT.AI.Flocking
{
    public class NullStrategy : FlockingStrategy
    {
        public override Vector3 Steering => Vector3.zero;
        public NullStrategy(
            IBoid host, 
            float weight = 1) 
            :base(host, weight) { }

    }
}
