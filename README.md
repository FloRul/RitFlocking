# RitFlocking
### A C# library for Unity3D engine to develop complex flocking behavior for AI agent


This library aims to provide a simple way to give motion to an autonomous agent.
It has been inspired by the book : Programming game AI by example by Mat Buckland.

Here are the different steering implemented : 
  - Flee
  - FleeTarget
  - Seek
  - SeekTarget
  - Wander
  - LeaderFollowing
  - SeparateStrategy

Each agent holds a list of strategies, each frame, this list is iterated and the resulting sterring is then calculated and used to move the agent transform.

Each strategies works like a pilot inside the agent, to create an agent you can create a class in unity and extending the FlockingAgent abstract class.
From then, all that the class needs to override are : the MaxSpeed allowed for the agent, the SlowingRadius used to decelerate the agent when he arrives near its target
and its mass used to calculate its inertia when moving.

Here I previously implemented a scriptable object BoidSetting to store the agent settings.
```csharp
using RIT.AI.Flocking;
using UnityEngine;

public class ConcreteAgent : FlockingAgent
{
    [SerializeField] BoidSettings _settings;

    public override float MaxSpeed => Mathf.Abs(_settings.maxSpeed);
    public override float SlowingRadius => _settings.slowingRadius;
    public override float Mass => Mathf.Abs(_settings.mass);
}

```

Once the agent class (MonoBeheviour) is created we only need to add it to any tranform from the unity editor.
For now the agent does not have any stering behavior on it, the easiest one to put is the wander one 
as it does not require any external parameter to work, here is the syntax : 

```csharp
using RIT.AI.Flocking;
using UnityEngine;

public class WanderManager
{
    [SerializeField] protected FlockingAgent[] _agents;

    void Start()
    {
        foreach (var agent in _agents)
        {
            agent.AddFlocking(new WanderStrategy(agent, 1, new WanderParams(Vector3.zero, 100, .1f, 1, 1)));
        }
    }

    private void Update()
    {
        foreach (var b in _agents)
        {
            b.UpdateSteering();
        }
    }
}
```

The manager needs a list of flocking agent, it iterates once at start to assign a strategy to each agent and updates them at each frame.
The WanderStrategy is the class encapsulating the steering calculation it requires :
  - A reference to the moving agent
  - The weight applied on this strategy (each strategy applied on an agent can have a relative weight to prioritize them)
  - And finally another WanderParams class, this one is use to define : 
    - Where is the wander area
    - What is its radius
    - The turn chance of the agent for each frame
    - The radius of the circle distance 
    - The distance of the circle from the agent
 For a better understanding of these 2 last parameters I recommand to consult [this article](https://gamedevelopment.tutsplus.com/tutorials/understanding-steering-behaviors-wander--gamedev-1624) explaining the principles behind the wander parameters
  
