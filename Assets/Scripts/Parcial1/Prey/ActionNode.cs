using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : P_Node
{
    public TypeAction type;

    public override void Execute(Boid boid)
    {
        switch (type)
        {
            case TypeAction.Flock:
                boid.Flocking();
                break;

            case TypeAction.Evade:
                boid.Evading();
                break;

            case TypeAction.Arrive:
                boid.Arriving();
                break;
        }
    }

    public enum TypeAction
    {
        Flock,
        Arrive,
        Evade
    }
}
