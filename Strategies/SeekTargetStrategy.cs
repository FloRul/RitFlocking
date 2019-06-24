using RIT.AI.Flocking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTargetStrategy : AbstractSeekStrategy
{
    readonly ITarget _seekTarget;
    protected override Vector3 TargetPosition => _seekTarget.Position;

    public SeekTargetStrategy(IBoid host, float weight, ITarget target) : base (host, weight)
    {
        _seekTarget = target;
    }
}
